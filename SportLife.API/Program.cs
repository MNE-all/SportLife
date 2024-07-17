using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SportLife.API.Infrastructures;
using SportLife.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// !!! Конфигурируем обработку пересылаемых заголовков запросов
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
// !!! Конфигурируем обработку пересылаемых заголовков запросов
builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add comments
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "SportLife.API.xml");
    options.IncludeXmlComments(xmlPath);
});

// Add Dep
builder.Services.AddDependencies();

var conStrBuilder = new NpgsqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("PostgreDatabase"));
conStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<SportLifeContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

// !!! Добавляем в конвеер обработки HTTP-запроса компонент работы с пересылаемыми заголовками
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
// !!! Добавляем в конвеер обработки HTTP-запроса компонент работы с пересылаемыми заголовками

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
