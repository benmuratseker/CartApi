using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartApi.Entities;
using CartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartContext db;

        public CartRepository(CartContext db)
        {
            this.db = db;
        }
        public DbSet<CartItem> GetAllCartItems()
        {
            return db.CartItems;
        }

        public CartItem GetCartItem(long id)
        {
            return db.CartItems.FirstOrDefault(i => i.ProductIdInCart == id);
        }

        public CartItem AddTocart(long productId, int quantity)
        {
            CartItem existingItem = GetCartItem(productId);
            if (existingItem != null)
            {
                Product addedProduct = db.Products.FirstOrDefault(p => p.Id == productId);
                if (quantity <= addedProduct.Stock)
                {
                    CartItem item = db.CartItems.FirstOrDefault(i => i.ProductIdInCart == productId);
                    item.Quantity += quantity;
                    item.UnitPrice = addedProduct.Price;
                   
                    addedProduct.Stock -= quantity;
                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Product addedProduct = db.Products.FirstOrDefault(p => p.Id == productId);
                if (quantity <= addedProduct.Stock)
                {
                    CartItem newCartItem = new CartItem {ProductIdInCart = productId, Quantity = quantity, UnitPrice = addedProduct.Price};
                    db.CartItems.Add(newCartItem);

                   
                    addedProduct.Stock -= quantity;
                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            return new CartItem(){ProductIdInCart = productId, Quantity = quantity};
        }

       
    }
}
