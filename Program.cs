using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Caso_1_tarea.Data;
using Caso_1_tarea.Repositories;
using Caso_1_tarea.Repositories.Interfaces;
using Caso_1_tarea.Services;
using Caso_1_tarea.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection") 
                      ?? "Host=localhost;Database=Caso1DB;Username=postgres;Password=tu_contraseña"));

// 2. Registrar Inyección de Dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductosService, ProductosService>();

// 3. Agregar Controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();