using EShopV3.Catalog.Mapping;
using EShopV3.Catalog.ServiceInjections;
using EShopV3.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";   //Bu tokena sahip ise bu katmana eri�im sa�layabilir
    opt.RequireHttpsMetadata = false; //Https yerine http kullan�m� i�in
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
