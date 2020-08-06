using System;

namespace Core.Entities
{
    public class OrderedItems : BaseEntity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
