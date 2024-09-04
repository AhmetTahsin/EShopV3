using EShopV3.Catalog.Dtos.BrandDtos;

namespace EShopV3.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createbrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updatebrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
    }
}
