namespace basket.api.Models
{
    public class BasketItem
    {
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
    }
}