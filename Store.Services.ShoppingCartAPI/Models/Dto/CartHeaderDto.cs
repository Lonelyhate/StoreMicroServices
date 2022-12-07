using System.ComponentModel.DataAnnotations;

namespace Store.Services.ShoppingCartAPI.Models;

public class CartHeader
{
    [Key]
    public int CartHeaderId { get; set; }
    public string UserId { get; set; }
    public string CuponCode { get; set; }
}