using basket.api.Models;

namespace basket.api.IRepos
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(string username);
        Task<Basket> UpdateBasket(Basket basket);
        Task<Basket> DeleteBasket(string username);
        Task<Basket> Checkout(BasketCheckout basketCheckout);
    }
}
