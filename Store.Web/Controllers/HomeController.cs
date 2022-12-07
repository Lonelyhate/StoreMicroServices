using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Web.Models;
using Store.Web.Models.Dto;
using Store.Web.Services.IServices;

namespace Store.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        List<ProductDto> productDtos = new List<ProductDto>();
        var response = await _productService.GetAllProductsAsync<ResponseDto>("");
        if (response != null && response.IsSuccess)
        {
            productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(response.Result.ToString());
        }
        
        return View(productDtos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Login()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Details(int productId)
    {
        ProductDto productDto = new ProductDto();
        var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, "");
        if (response is not null && response.IsSuccess)
        {
            productDto = JsonConvert.DeserializeObject<ProductDto>(response.Result.ToString());
        }

        return View(productDto);
    }
}