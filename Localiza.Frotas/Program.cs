using FluentAssertions.Common;
using Localiza.Frotas.Infra.Singleton;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Localiza.Frotas",
        Description = " API - FROTAS",
        Version = "v1"
    });

    var apiPath = Path.Combine(AppContext.BaseDirectory, "Localiza.Frotas.xml");
    c.IncludeXmlComments(apiPath);
});
builder.Services.AddSingleton<SingletonContainer>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Localiza.Frotas");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
