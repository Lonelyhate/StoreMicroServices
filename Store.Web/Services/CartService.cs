using Store.Web.Models;
using Store.Web.Models.Carts.Dto;
using Store.Web.Services.IServices;

namespace Store.Web.Services;

public class CartService : BaseService, ICartService
{
    private readonly IHttpClientFactory _clientFactory;

    public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ShoppingApiBase + "/api/cart/GetCart/" + userId,
            AccessToken = token
        });
    }

    public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingApiBase + "/api/cart/AddCart",
            AccessToken = token
        });
    }

    public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingApiBase + "/api/cart/UpdateCart",
            AccessToken = token
        });
    }

    public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartId,
            Url = SD.ShoppingApiBase + "/api/cart/RemoveCart",
            AccessToken = token
        });
    }
}