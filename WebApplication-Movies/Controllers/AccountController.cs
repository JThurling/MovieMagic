using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Inputs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Movies.Attributes;

namespace WebApplication_Movies.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAuth _auth;
        private readonly IMapper _mapper;

        public AccountController(IAuth auth, IMapper mapper)
        {
            _auth = auth;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(Register user)
        {
            user.Email = user.Email.ToLower();

            if (await _auth.UserExists(user.Email)) return BadRequest("User Exists");

            var createUser = await _auth.Register(user);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<User> Login(Login login)
        {
            var loginUser = await _auth.Login(login);

            if (login == null) return new User();

            return _mapper.Map<Users, User>(loginUser);
        }


    }
}
