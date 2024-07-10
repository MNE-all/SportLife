using Microsoft.EntityFrameworkCore;
using Npgsql;
using SportLife.API.Infrastructures;
using SportLife.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
