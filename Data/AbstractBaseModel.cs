using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data
{
    public class AbstractBaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
