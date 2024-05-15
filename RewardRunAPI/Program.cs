using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RewardRunAPI.Connections;

var builder = WebApplication.CreateBuilder(args);

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseMySQL("Server=localhost;User Id=rewardrun;Password=@WSXcde3;Database=rewardrun"));

// Adicionar os controladores da API
builder.Services.AddControllers();

// Adicionar o serviço do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RewardRun", Version = "v1" });
});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:8100")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// Habilitar CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
