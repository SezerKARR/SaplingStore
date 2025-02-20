using System.Net;
using dotenv.net; // Dotenv paketini ekleyin
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SaplingStore.Data;
using SaplingStore.Interfaces;
using SaplingStore.Mapper;
using SaplingStore.Models;
using SaplingStore.Repository;
using SaplingStore.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// .env dosyasını yükleyin
DotEnv.Load();
var connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")};" +
                       $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                       $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                       $"User={Environment.GetEnvironmentVariable("DB_USER")};" +
                       $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";

// CORS yapılandırması
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Tüm kaynaklardan gelen istekleri kabul et
            .AllowAnyMethod()  // Herhangi bir HTTP metodunu kabul et
            .AllowAnyHeader();  // Herhangi bir başlık kabul et
    });
});

// AutoMapper ve diğer servisler
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// MySQL Bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
    ServiceLifetime.Scoped);

// Identity yapılandırması
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();

var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
var jwtSigningKey = Environment.GetEnvironmentVariable("JWT_SIGNINGKEY") ?? string.Empty;

// JWT doğrulama
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        options.DefaultScheme = options.DefaultChallengeScheme = options.DefaultForbidScheme =
            options.DefaultSignInScheme = options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtIssuer,
        ValidateAudience = true,
        ValidAudience = jwtAudience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSigningKey))
    };
});

// Repository ve Servisler
builder.Services.AddScoped<IClassRepository<Sapling>, SaplingRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IClassRepository<SaplingCategory>, SaplingCategoryRepository>();
builder.Services.AddScoped<IClassRepository<SaplingHeight>, SaplingHeightRepository>();

// Kestrel yapılandırması
if (builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(IPAddress.Any, 5000);  // HTTP üzerinden port 5000'de dinle
        // HTTPS yapılandırmasını kaldırdık
    });
}
else
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(IPAddress.Any, 80);  // Render'da HTTP portu
        // Port 443 ve HTTPS yapılandırması Render tarafından otomatik olarak sağlanır
    });
}

var app = builder.Build();
app.UseRouting();
app.MapGet("/asd", () => "Hello World!");

// HTTP isteklerini yönlendirme ve Swagger yapılandırması
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();  // Apply it globally
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
