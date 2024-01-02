using Service_Product.Model;

namespace Service_Product.Service.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product, int productId);
        Task<Product> DeleteProductAsync(int productId);
    }
}
