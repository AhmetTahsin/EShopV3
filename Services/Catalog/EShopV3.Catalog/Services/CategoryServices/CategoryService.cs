using AutoMapper;
using EShopV3.Catalog.Dtos.CategoryDtos;
using EShopV3.Catalog.Entities;
using EShopV3.Catalog.Settings;
using MongoDB.Driver;

namespace EShopV3.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);//Bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);   //Database
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);  //Tablo
            _mapper = mapper;
        }
        /// <summary>
        /// MongoDb Ekleme Metodu
        /// </summary>
        /// <param name="createcategoryDto"></param>
        /// <returns></returns>
        public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            var value=_mapper.Map<Category>(createcategoryDto);
            await _categoryCollection.InsertOneAsync(value); 
        }
        /// <summary>
        /// MongoDb ID'ye göre silme metodu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);
        }
        /// <summary>
        /// MongoDb Listeleme
        /// </summary>
        /// <returns></returns>
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values=await _categoryCollection.Find(x=> true).ToListAsync(); //x=>true hepsini listelemek için
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }
        /// <summary>
        /// MongoDb Tek Deger Çekme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values=await _categoryCollection.Find<Category>(x=>x.CategoryID == id).FirstOrDefaultAsync(); //Find ile şarta göre bul sonra degeri al
            return _mapper.Map<GetByIdCategoryDto>(values);
        }
        /// <summary>
        /// MongoDb Guncelleme
        /// </summary>
        /// <param name="updatecategoryDto"></param>
        /// <returns></returns>
        public async Task UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto)
        {
            var values=_mapper.Map<Category>(updatecategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID == updatecategoryDto.CategoryID, values); //MongoDb Guncelleme metodu
        }
    }
}
