using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Interfaces;
using SaplingStore.Models;
using SaplingStore.Mapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

var services = new ServiceCollection();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options=>options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IClassRepository<Sapling>, ClassRepository<Sapling>>();
builder.Services.AddScoped<IClassRepository<SaplingCategory>, ClassRepository<SaplingCategory>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
