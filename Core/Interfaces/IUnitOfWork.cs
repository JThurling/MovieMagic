using System.Threading.Tasks;
using Core.Inputs;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<string> Order(OrderInput input);
    }
}
