using EShopV3.Catalog.Services.CategoryServices;
using EShopV3.Catalog.Services.ProductDetailServices;
using EShopV3.Catalog.Services.ProductImageServices;
using EShopV3.Catalog.Services.ProductServices;

namespace EShopV3.Catalog.ServiceInjections
{
    public static class CostumScopedService
    {
        public static IServiceCollection AddScopeService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();

            return services;
        }
    }
}
