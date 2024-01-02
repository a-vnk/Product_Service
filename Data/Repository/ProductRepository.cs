using Microsoft.EntityFrameworkCore;
using Service_Product.Data.Repository.Interface;
using Service_Product.Model;

namespace Service_Product.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _contextProduct;
        public ProductRepository(ProductDbContext contextProduct)
        {
            _contextProduct = contextProduct;
        }

        public async Task<List<Product>> GetProductsAsync()
        {

            var elements = await _contextProduct.Products.ToListAsync().ConfigureAwait(false);

            return elements;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var element = await _contextProduct.Products.FirstOrDefaultAsync(product => product.ProductId == productId).ConfigureAwait(false);

            return element;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var elementAdded = await _contextProduct.Products.AddAsync(product).ConfigureAwait(false);

            await _contextProduct.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var elementUpdated = _contextProduct.Products.Update(product);

            await _contextProduct.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            var elementDeleted = _contextProduct.Products.Remove(product);

            await _contextProduct.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;

        }
    }
}
