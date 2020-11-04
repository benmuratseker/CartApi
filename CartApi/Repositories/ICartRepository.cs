using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Repositories
{
    public interface ICartRepository
    {
        DbSet<CartItem> GetAllCartItems();
        CartItem GetCartItem(long id);
        CartItem AddTocart(long productId, int quantity);
    }
}
