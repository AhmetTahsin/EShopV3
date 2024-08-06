using EShopV3.Catalog.Dtos.SpecialOfferDtos;

namespace EShopV3.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createcategoryDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updatecategoryDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
