using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrder
    {
        public Task<IReadOnlyList<Order>> OrderedMovie();
        // public Task<IReadOnlyList<Order>> OrderedMovie(IReadOnlyList<Order> order);
    }
}
