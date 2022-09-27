namespace catalog.api.Models.SearchObject
{
    public class ProductSearchObject : BaseSearchObject
    {
        public string? id { get; set; } 
        public string? category_id { get; set; }
        public string? name { get; set; }
    }
}
