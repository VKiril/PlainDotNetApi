using PlainDotNetApi.Data.Models;
using PlainDotNetApi.Data.Repositories.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data.Repositories.Product
{
    public class ProductRepository: BaseRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(PGDatabaseContext context)
            : base(context)
        {
        }
    }
}
