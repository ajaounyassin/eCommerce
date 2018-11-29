using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class Address
    {
        public Guid UserId { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
