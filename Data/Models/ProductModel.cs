using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlainDotNetApi.Data.Models
{
    public class ProductModel : AbstractBaseModel
    {
        public string Name { get; set; }
        [ForeignKey("CartId")]
        public Guid CartId { get; set; }
        public CartModel Cart { get; set; }
    }
}
