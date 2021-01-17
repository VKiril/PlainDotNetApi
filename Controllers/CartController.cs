using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlainDotNetApi.Data;
using PlainDotNetApi.Data.Models;
using PlainDotNetApi.Data.Repositories.Cart.Interfaces;

namespace PlainDotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<IEnumerable<CartModel>> GetCarts()
        {
            return await _cartRepository.GetListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartModel>> GetCart(Guid id)
        {
            var cart = await _cartRepository.GetAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Cart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(Guid id, CartModel cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            try
            {
                _cartRepository.Update(cart);
                await _cartRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_cartRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartModel>> PostCart(CartModel cart)
        {
            _cartRepository.Add(cart);
            await _cartRepository.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartModel>> DeleteCart(Guid id)
        {
            var cart = await _cartRepository.GetAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _cartRepository.Remove(cart);
            await _cartRepository.SaveChangesAsync();

            return cart;
        }
    }
}
