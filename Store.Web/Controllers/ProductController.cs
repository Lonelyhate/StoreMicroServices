using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Web.Models.Dto;
using Store.Web.Services.IServices;

namespace Store.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        List<ProductDto> list = new List<ProductDto>();
        var response = await _productService.GetAllProductsAsync<ResponseDto>();
        if (response is not null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
        }

        return View(list);
    }
}