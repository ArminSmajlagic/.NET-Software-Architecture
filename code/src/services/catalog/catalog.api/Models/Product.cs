using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace catalog.api.Models
{
    public class Product
    {
        [BsonId]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public string category_id { get; set; }
    }
}
