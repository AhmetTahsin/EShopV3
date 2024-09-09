using EShopV3.Catalog.Services.AboutServices;
using EShopV3.Catalog.Services.BrandServices;
using EShopV3.Catalog.Services.CategoryServices;
using EShopV3.Catalog.Services.FeatureServices;
using EShopV3.Catalog.Services.FeatureSliderServices;
using EShopV3.Catalog.Services.OfferDiscountServices;
using EShopV3.Catalog.Services.ProductDetailServices;
using EShopV3.Catalog.Services.ProductImageServices;
using EShopV3.Catalog.Services.ProductServices;
using EShopV3.Catalog.Services.SpecialOfferServices;

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
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IOfferDiscountService, OfferDiscountService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAboutService, AboutService>();


            return services;
        }
    }
}
