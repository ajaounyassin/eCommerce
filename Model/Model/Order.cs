using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid BasketId { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public Status Status { get; set; }
        public bool Payement { get; set; }
    }
}
