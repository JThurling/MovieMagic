using System.Collections.Generic;
using Core.Entities;

namespace WebApplication_Movies.Dto
{
    public class OrderedMoviesDtos
    {
        public Order Order { get; }
        public double Subtotal { get; }

        public OrderedMoviesDtos(Order order, double subtotal)
        {
            Order = order;
            Subtotal = subtotal;
        }
    }
}
