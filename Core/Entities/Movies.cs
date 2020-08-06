using System;

namespace Core.Entities
{
    public class Movies : BaseEntity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }
}
