using System;
namespace Model.Model
{
    public class Mouvment
    {
        private Guid Id { get; set; }
        private Article Article { get; set; }
        private int Quantity { get; set; }
        private DateTime Date { get; set; }
    }
}
