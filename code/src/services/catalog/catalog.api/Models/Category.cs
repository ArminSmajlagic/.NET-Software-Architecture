using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace catalog.api.Models
{
    public class Category
    {
        [BsonId]
        public string id { get; set; }
        public string name { get; set; }
        public string decription { get; set; }
    }
}
