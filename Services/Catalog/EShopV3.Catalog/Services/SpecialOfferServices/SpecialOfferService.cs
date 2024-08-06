using AutoMapper;
using EShopV3.Catalog.Dtos.SpecialOfferDtos;
using EShopV3.Catalog.Entities;
using EShopV3.Catalog.Settings;
using MongoDB.Driver;

namespace EShopV3.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);   //Database
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);  //Tablo
            _mapper = mapper;
        }
        /// <summary>
        /// MongoDb Ekleme Metodu
        /// </summary>
        /// <param name="createSpecialOfferDto"></param>
        /// <returns></returns>
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }
        /// <summary>
        /// MongoDb ID'ye göre silme metodu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }
        /// <summary>
        /// MongoDb Listeleme
        /// </summary>
        /// <returns></returns>
        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync(); //x=>true hepsini listelemek için
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }
        /// <summary>
        /// MongoDb Tek Deger Çekme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var values = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId == id).FirstOrDefaultAsync(); //Find ile şarta göre bul sonra degeri al
            return _mapper.Map<GetByIdSpecialOfferDto>(values);
        }
        /// <summary>
        /// MongoDb Guncelleme
        /// </summary>
        /// <param name="updatespecialOfferDto"></param>
        /// <returns></returns>
        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, values); //MongoDb Guncelleme metodu
        }
    }
}
