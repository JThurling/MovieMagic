using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Inputs;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AuthService : IAuth
    {
        private readonly MovieContext _context;

        public AuthService(MovieContext context)
        {
            _context = context;
        }

        public async Task<Users> Register(Register register)
        {
            if (register == null) return null;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

            var user = new Users
            {
                FirstName = register.FirstName,
                Surname = register.Surname,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                PassSalt = passwordSalt,
                PassHash = passwordHash,
                Role = "visitor",
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string registerPassword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerPassword));
            }
        }

        public async Task<Users> Login(Login login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);

            if (user == null) return null;
            if (!VerifyPasswordHash(login.Password, user.PassHash, user.PassSalt)) return null;
            return user;
        }

        public async Task<bool> UserExists(string register)
        {
            if (await _context.Users.AnyAsync(x => x.Email == register))
                return true;

            return false;
        }

        private bool VerifyPasswordHash(string loginPassword, byte[] userPassHash, byte[] userPassSalt)
        {
            using (var hmac = new HMACSHA512(userPassSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginPassword));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPassHash[i]) return false;
                }

                return true;
            }
        }
    }
}
