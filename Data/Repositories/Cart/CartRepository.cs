using PlainDotNetApi.Data.Models;
using PlainDotNetApi.Data.Repositories.Cart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data.Repositories.Cart
{
    public class CartRepository : BaseRepository<CartModel>, ICartRepository
    {
        public CartRepository(PGDatabaseContext _context)
            : base(_context)
        {
        }
    }
}
