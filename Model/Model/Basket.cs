using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class Basket
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public Guid ArticleId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
