using System;
namespace Model.Model
{
    public class Inventory
    {
        private Guid Id { get; set; }
        private Article Article { get; set; }
        private int Quantity { get; set; }
        private DateTime Date { get; set; }
        }
}
