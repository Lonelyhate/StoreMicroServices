using Store.Services.ProductAPI.Models.Dto;

namespace Store.Services.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int productId);
    Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
    Task<bool> DeleteProduct(int productId);
}