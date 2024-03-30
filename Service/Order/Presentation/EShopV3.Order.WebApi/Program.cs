using EShopV3.Order.Application.Interfaces;
using EShopV3.Order.Application.Services;
using EShopV3.Order.Persistence.Context;
using EShopV3.Order.Persistence.Respositories;
using EShopV3.Order.WebApi.ServiceInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext <OrderContext>();

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddScopeService(); //ServiceInjections iþlemi yaptým


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

app.UseAuthorization();

app.MapControllers();

app.Run();
