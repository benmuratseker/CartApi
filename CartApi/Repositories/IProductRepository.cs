using CartApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Repositories
{
    public interface IProductRepository
    {
        DbSet<Product> GetAllProducts();
        Product GetProduct(long id);
        Product GetProduct(string code);
        Product CreateProduct(Product product);
        void UpdateProduct(long id, Product product);
        void UpdateProduct(string code, Product product);
        void DeleteProduct(long id);
        void DeleteProduct(string code);
    }
}
