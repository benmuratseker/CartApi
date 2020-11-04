using CartApi.Entities;
using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CartContext db;

        public ProductRepository(CartContext db)
        {
            this.db = db;
        }

        public DbSet<Product> GetAllProducts()
        {
            return db.Products;
        }

        public Product GetProduct(long id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }
        public Product GetProduct(string code)
        {
            return db.Products.FirstOrDefault(p => p.Code == code);
        }

        public Product CreateProduct(Product product)
        {
            if (!db.Products.Any(p => p.Id == product.Id))
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            return product;
        }

        public void UpdateProduct(long id, Product product)
        {
            Product oldProduct = GetProduct(id);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                oldProduct.Stock = product.Stock;

                db.SaveChanges();
            }
        }

        public void UpdateProduct(string code, Product product)
        {
            Product oldProduct = GetProduct(code);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                oldProduct.Stock = product.Stock;

                db.SaveChanges();
            }
        }

        public void DeleteProduct(long id)
        {
            Product willBeDeleted = GetProduct(id);
            if (willBeDeleted != null)
            {
                db.Products.Remove(willBeDeleted);
                db.SaveChanges();
            }
        }

        public void DeleteProduct(string code)
        {
            Product willBeDeleted = GetProduct(code);
            if (willBeDeleted != null)
            {
                db.Products.Remove(willBeDeleted);
                db.SaveChanges();
            }
        }
    }
}
