using AutoMapper;
using basket.api.IRepos;
using basket.api.Models;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace basket.api.Repos
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache redisCache;
        private readonly IMapper mapper;
        private readonly ILogger<BasketRepository> logger;
        private readonly IPublishEndpoint publishEndpoint;

        public BasketRepository(IDistributedCache redisCache,IMapper mapper,ILogger<BasketRepository> logger, IPublishEndpoint publishEndpoint)
        {
            this.redisCache = redisCache;
            this.mapper = mapper;
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<Basket> DeleteBasket(string username)
        {
            var basket = await GetBasket(username);

            await redisCache.RemoveAsync(username);

            logger.LogInformation($"Basket with username : {username} was successfully deleted",DateTime.Now);

            return basket;
        }

        public async Task<Basket> GetBasket(string username)
        {
            var result = await redisCache.GetStringAsync(username);

            if (result == null)
                return null;

            return JsonConvert.DeserializeObject<Basket>(result);
        }


        public async Task<Basket> UpdateBasket(Basket basket)
        {
            var jsonBasket = JsonConvert.SerializeObject(basket);

            await redisCache.SetStringAsync(basket.username,jsonBasket);

            logger.LogInformation($"Basket with username : {basket.username} was successfully updated", DateTime.Now);


            return basket;
        }

        public async Task<Basket> Checkout(BasketCheckout basketCheckout)
        {
            var basket = await GetBasket(basketCheckout.username);

            if (basket == null)
                return null;

            decimal sum = 0;

            foreach (var item in basket.items)
            {
                sum += item.price * item.quantity;
            }

            var eventMessage = mapper.Map<BasketCheckoutEvent>(basketCheckout);

            eventMessage.total_price = sum;

            await publishEndpoint.Publish(eventMessage);

            var deletedBasket = await DeleteBasket(basketCheckout.username);

            logger.LogInformation($"Basket with username : {basket.username} was successfully checked out", DateTime.Now);

            return deletedBasket;
        }
    }
}
