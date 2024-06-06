using EShopV3.Cargo.BusinessLayer.Abstract;
using EShopV3.Cargo.BusinessLayer.Concrete;
using EShopV3.Cargo.DataAccessLayer.Abstract;
using EShopV3.Cargo.DataAccessLayer.Concrete;
using EShopV3.Cargo.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";   //Bu tokena sahip ise bu katmana eri�im sa�layabilir
    opt.RequireHttpsMetadata = false; //Https yerine http kullan�m� i�in
});

builder.Services.AddDbContext<CargoContext>();
builder.Services.AddScoped<ICargoCompanyDal, EFCargoCompanyDal>();
builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerDal, EFCargoCustomerDal>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailDal, EFCargoDetailDal>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoOperationDal, EFCargoOperationDal>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
