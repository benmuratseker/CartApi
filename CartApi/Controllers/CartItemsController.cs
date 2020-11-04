using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartApi.Entities;
using CartApi.Models;
using CartApi.Repositories;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartRepository _context;

        public CartItemsController(ICartRepository context)
        {
            _context = context;
            if (!_context.GetAllCartItems().Any())
            {
                _context.AddTocart(2, 5);
            }
           
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.GetAllCartItems().ToListAsync();
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(long id)
        {
            var cartItem = await _context.GetAllCartItems().FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return cartItem;
        }

     

        // POST: api/CartItems
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem item)
        {
            _context.AddTocart(item.ProductIdInCart, item.Quantity);

            return CreatedAtAction("GetCartItem", new { id = item.Id }, item);
        }

      
        private bool CartItemExists(long id)
        {
            return _context.GetAllCartItems().Any(e => e.ProductIdInCart == id);
        }
    }
}
