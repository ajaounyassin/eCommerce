﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class Article
    {
        public Guid Id { get; set; }
        public User Vendor { get; set; }
        public string Wording { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal PriceET { get; set; }
        public string Category { get; set; }
        public decimal Tax { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryTime { get; set; }
        public bool Active { get; set; }
        public bool Top { get; set; }
    }
}
