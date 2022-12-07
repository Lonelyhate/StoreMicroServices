using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Services.ProductAPI.Models.Dto;
using Store.Services.ProductAPI.Repository;

namespace Store.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductApiController : ControllerBase
{
    protected ResponseDto _response;
    private IProductRepository _productRepository;

    public ProductApiController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        this._response = new ResponseDto();
    }
    
    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            _response.Result = productDtos;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _response;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductDto productDto = await _productRepository.GetProductById(id);
            _response.Result = productDto;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { e.Message.ToString() };
        }

        return _response;
    }

    [HttpPost]
    [Authorize]
    public async Task<object> Post([FromBody] ProductDto productDtoData)
    {
        try
        {
            ProductDto productDto = await _productRepository.CreateUpdateProduct(productDtoData);
            _response.Result = productDto;
        }
        catch(Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { e.Message.ToString() };
        }

        return _response;
    }
    
    [HttpPut]
    [Authorize]
    public async Task<object> Put([FromBody] ProductDto productDtoData)
    {
        try
        {
            ProductDto productDto = await _productRepository.CreateUpdateProduct(productDtoData);
            _response.Result = productDto;
        }
        catch(Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { e.Message.ToString() };
        }

        return _response;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _productRepository.DeleteProduct(id);
            _response.Result = isSuccess;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { e.Message.ToString() };
        }

        return _response;
    }
}