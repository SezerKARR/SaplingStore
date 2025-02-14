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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Tüm kaynaklardan gelen istekleri kabul et
            .AllowAnyMethod()  // Herhangi bir HTTP metodunu kabul et
            .AllowAnyHeader();  // Herhangi bir başlık kabul et
    });
});
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

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString),
    ServiceLifetime.Scoped);

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();

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
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"] ?? string.Empty))
    };
});
builder.Services.AddScoped<IClassRepository<Sapling>, SaplingRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IClassRepository<SaplingCategory>, SaplingCategoryRepository>();
builder.Services.AddScoped<IClassRepository<SaplingHeight>, SaplingHeightRepository>();

if (builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(IPAddress.Any, 5000);  // HTTP üzerinden port 5000'de dinle
        options.Listen(IPAddress.Any, 5001, listenOptions =>
        {
            listenOptions.UseHttps();  // HTTPS üzerinden port 5001 (geliştirme ortamında)
        });
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
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();  // Apply it globally
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
