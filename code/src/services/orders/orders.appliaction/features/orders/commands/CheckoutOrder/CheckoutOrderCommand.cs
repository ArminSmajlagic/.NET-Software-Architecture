using MediatR;

namespace orders.appliaction.features.orders.commands.CheckoutOrder
{
    public class CheckoutOrderCommand : IRequest<int>
    {
        public string username { get; set; }
        public decimal total_price { get; set; }
        public int user_id { get; set; }
        public int payment_id { get; set; }

    }
}
