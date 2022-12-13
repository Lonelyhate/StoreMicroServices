using Store.Web.Models.Dto;

namespace Store.Web.Models.Carts.Dto;

public class CartDetailsDto
{
    public int CartDetailsId { get; set; }
    public int CartHeaderId { get; set; }
    public virtual CartHeaderDto CartHeader { get; set; }
    public int ProductId { get; set; }
    public virtual ProductDto Product { get; set; }
    public int Count { get; set; }
}