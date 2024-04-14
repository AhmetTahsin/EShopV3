using EShopV3.Order.Application.Features.CORS.Handlers.AddressHandlers;
using EShopV3.Order.Application.Features.CORS.Handlers.OrderDetailHandlers;
using EShopV3.Order.Application.Features.CORS.Queries.OrderDetailQueries;

namespace EShopV3.Order.WebApi.ServiceInjections
{
    public static class CostumScopedService
    {
        public static IServiceCollection AddScopeService(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();

            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
            
            return services;
        }
    }
}
