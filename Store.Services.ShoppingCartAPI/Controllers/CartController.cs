using Microsoft.AspNetCore.Mvc;
using Store.Services.ProductAPI.Models.Dto;
using Store.Services.ShoppingCartAPI.Models;
using Store.Services.ShoppingCartAPI.Repository;

namespace Store.Services.ShoppingCartAPI.Controllers;

[ApiController]
[Route("api/cart")]
public class CartController : Controller
{
    private readonly ICartRepository _cartRepository;
    protected ResponseDto _response;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
        _response = new ResponseDto();
    }

    [HttpGet("GetCart/{userId}")]
    public async Task<object> GetCart(string userId)
    {
        try
        {
            CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
            _response.Result = cartDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPost("AddCart")]
    public async Task<object> AddCart(CartDto cartDto)
    {
        Console.WriteLine(1);
        try
        {
            CartDto cart = await _cartRepository.CreateUpdateCart(cartDto);
            _response.Result = cart;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPost("UpdateCart")]
    public async Task<object> UpdateCart(CartDto cartDto)
    {
        try
        {
            CartDto cart = await _cartRepository.CreateUpdateCart(cartDto);
            _response.Result = cart;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPost("RemoveCart")]
    public async Task<object> RemoveCart([FromBody]int cartId)
    {
        try
        {
            bool isSuccess = await _cartRepository.RemoveFromCart(cartId);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpGet("CleanCart/{userId}")]
    public async Task<object> CleanCart(string userId)
    {
        try
        {
            bool isSuccess = await _cartRepository.ClearCart(userId);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string>() { ex.ToString() };
        }

        return _response;
    }
}