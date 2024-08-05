using EShopV3.Catalog.Dtos.FeatureSliderDtos;

namespace EShopV3.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createcategoryDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updatecategoryDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChageStatusToTrue(string id);
        Task FeatureSliderChageStatusToFalse(string id);

    }
}
