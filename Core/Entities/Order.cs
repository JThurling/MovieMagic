using System.Collections.Generic;

namespace Core.Entities
{
    public class Order : BaseEntity
    {
        public IList<OrderedItems> Movies { get; set; }
        public string Email { get; set; }

        public double Subtotal { get; set; }
    }
}
