using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Inputs;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieContext _context;
        private readonly IMapper _map;

        public UnitOfWork(MovieContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        public async Task<string> Order(OrderInput input)
        {
            if (input == null) return "Nothing";

            var order = new Order
            {
                Email = input.email
            };

            var ordered = _context.Orders.Add(order);
            int result = await _context.SaveChangesAsync();
            if (result == 0) return "Failed";

            var orderedItems = new List<OrderedItems>();
            foreach (var movie in input.Movies)
            {
                orderedItems.Add(new OrderedItems
                {
                    Genre = movie.Genre,
                    Price = movie.Price,
                    Title = movie.Title,
                    OrderId = ordered.Entity.Id
                });
            }

            foreach (var item in orderedItems)
            {
                _context.OrderItems.Add(item);
            }

            int check = await _context.SaveChangesAsync();
            if (check == 0) return "Failed";

            if (result == 1) return "Success";

            return "Nothing Happened";
        }
    }
}
