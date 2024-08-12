using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShopV3.Catalog.Entities
{
    public class Category
    {
        [BsonId]    //Id oldugunu belirtmek için MongoDb
        [BsonRepresentation(BsonType.ObjectId)]//Unike Oldugunu belirtmek için 
        public string CategoryID { get; set; }//MongoDb'de string olarak tutulur
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
