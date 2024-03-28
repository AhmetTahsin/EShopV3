using EShopV3.Catalog.Mapping;
using EShopV3.Catalog.ServiceInjections;
using EShopV3.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScopeService(); //Service Injection yaptim
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //appsettingjson ayarlar�n� g�rmesi i�in
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
}); //DatabaseSettings S�n�f�na eri�mesini sa�lad�k ba�lant� i�in


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

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
