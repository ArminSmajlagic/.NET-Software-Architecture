namespace basket.api.Models
{
    public class BasketCheckout
    {
        public string username { get; set; }
        public decimal total_price { get; set; }
        public int user_id { get; set; }
        public int payment_id { get; set; } = 0;
    }
}