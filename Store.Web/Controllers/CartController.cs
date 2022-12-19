using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Web.Models.Carts.Dto;
using Store.Web.Models.Dto;
using Store.Web.Services.IServices;

namespace Store.Web.Controllers;

public class CartController : Controller
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public CartController(IProductService productService, ICartService cartService)
    {
        _productService = productService;
        _cartService = cartService;
    }

    public async Task<IActionResult> CartIndex()
    {
        return View(await LoadCartDtoBasedLoggedInUser());
    }

    private async Task<CartDto> LoadCartDtoBasedLoggedInUser()
    {
        var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _cartService.GetCartByUserIdAsync<ResponseDto>(userId, accessToken);

        CartDto cartDto = new CartDto();
        if (response is not null && response.IsSuccess)
        {
            cartDto = JsonConvert.DeserializeObject<CartDto>(response.Result.ToString());
        }

        if (cartDto.CartHeader is not null)
        {
            foreach (var detail in cartDto.CartDetails)
            {
                cartDto.CartHeader.OrderTotal += (detail.Product.Price * detail.Count);
            }
        }

        return cartDto;
    }
}