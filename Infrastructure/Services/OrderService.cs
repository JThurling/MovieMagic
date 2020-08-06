using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class OrderService : IOrder
    {
        private readonly MovieContext _context;

        public OrderService(MovieContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<Order>> OrderedMovie()
        {
            var test = _context.Orders.Include(x => x.Movies).ToListAsync();

            double price = 0;

            var addedProducts = new List<Order>();

            foreach (var order in test.Result)
            {
                foreach (var movie in order.Movies)
                {
                    price += movie.Price;
                }

                addedProducts.Add(new Order
                {
                    Email = order.Email,
                    Id = order.Id,

                    Movies = order.Movies,
                    Subtotal = price
                });

                price = 0;
            }

            return addedProducts;
        }
    }

    //     public async Task<IReadOnlyList<Order>> OrderedMovie(IReadOnlyList<Order> order)
    //     {
    //         var addedProducts = new List<Order>();
    //         foreach (var item in order)
    //         {
    //             foreach (var movie in item.Movies)
    //             {
    //                 movie.Order = null;
    //                 movie.Genre = order.Email,
    //                 movie.Id = order.Id,
    //
    //                 movie.Movies = order.Movies,
    //                 movie.Subtotal = price
    //             }
    //             addedProducts.Add(new Order
    //             {
    //                 Email = item.Email,
    //                 Id = item.Id,
    //                 Movies = item.Movies,
    //                 Subtotal = item.Subtotal
    //             });
    //         }
    //     // }
    // }
}
