using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data.Models
{
    public class CartModel : AbstractBaseModel
    {
        public int NumberOfProducts { get; set; }

        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
