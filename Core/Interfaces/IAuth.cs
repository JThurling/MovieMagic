using System.Threading.Tasks;
using Core.Entities;
using Core.Inputs;

namespace Core.Interfaces
{
    public interface IAuth
    {
        public Task<Users> Register(Register register);
        public Task<Users> Login(Login register);
        public Task<bool> UserExists(string email);
    }
}
