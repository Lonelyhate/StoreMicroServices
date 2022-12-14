using Store.Web.Models;
using Store.Web.Models.Dto;
using Store.Web.Services.IServices;

namespace Store.Web.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
        _clientFactory = httpClientFactory;
    }

    public async Task<T> GetAllProductsAsync<T>(string token)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products/",
            AccessToken = token
        });
    }

    public async Task<T> GetProductByIdAsync<T>(int id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + $"/api/products/{id}",
            AccessToken = token
        });
    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = productDto,
            Url =  SD.ProductApiBase + "/api/products",
            AccessToken = token
        });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = productDto,
            Url = SD.ProductApiBase + "/api/products",
            AccessToken = token
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.ProductApiBase + $"/api/products/{id}",
            AccessToken = token
        });
    }
}