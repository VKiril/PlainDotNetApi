using System;

namespace PlainDotNetApi.Data.RequestModels
{
    public class CartRequestModel
    {
        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }
    }
}
