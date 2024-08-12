using AutoMapper;
using EShopV3.Catalog.Dtos.FeatureDtos;
using EShopV3.Catalog.Entities;
using EShopV3.Catalog.Settings;
using MongoDB.Driver;

namespace EShopV3.Catalog.Services.FeatureServices
{
    public class FeatureService:IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;
        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);   //Database
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);  //Tablo
            _mapper = mapper;
        }
        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDt)
        {
            var value = _mapper.Map<Feature>(createFeatureDt);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public Task FeatureChageStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureChageStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync(); //x=>true hepsini listelemek için
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, values);
        }
    }
}
