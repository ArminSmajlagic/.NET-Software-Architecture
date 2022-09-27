namespace basket.api.Models
{
    public class Basket
    {
        public string id  { get; set; }
        public string username  { get; set; }
        public decimal total_price  { get; set; }
        public List<BasketItem> items  { get; set; }

        
    }
}
