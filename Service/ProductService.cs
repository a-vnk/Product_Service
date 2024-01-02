using Service_Product.Data.Repository.Interface;
using Service_Product.Model;
using Service_Product.Service.Interface;

namespace Service_Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetProductList()
        {
            return await _productRepository.GetProductsAsync().ConfigureAwait(false);
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            var productAdded = await _productRepository.CreateProductAsync(product);

            return productAdded;
        }
        public async Task<Product> UpdateProductAsync(Product product, int productId)
        {
            var productGet = await _productRepository.GetProductByIdAsync(productId).ConfigureAwait(false);
            if (productGet == null)
                throw new Exception($"Le produit avec cet identifiant {productId} n'existe pas");
            productGet.ProductName = product.ProductName;
            productGet.ProductPrice = product.ProductPrice;
            productGet.ProductStock = product.ProductStock;
            productGet.ProductDescription = product.ProductDescription;

            await _productRepository.UpdateProductAsync(productGet).ConfigureAwait(false);

            return productGet;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var productGet = await _productRepository.GetProductByIdAsync(productId).ConfigureAwait(false);

            if (productGet == null)
                throw new Exception($"Le produit avec cet identifiant {productId} n'existe pas");

            var productDeleted = await _productRepository.DeleteProductAsync(productGet).ConfigureAwait(false);

            return productDeleted;
        }
    }
}
