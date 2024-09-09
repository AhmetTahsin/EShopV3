﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EShopV3.Catalog.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string Desciription { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
