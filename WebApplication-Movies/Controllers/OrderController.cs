using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Inputs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Movies.Dto;

namespace WebApplication_Movies.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrder _order;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IOrder order, IUnitOfWork unitOfWork)
        {
            _order = order;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> OrderedMovies(OrderInput input)
        {
            var obj = _unitOfWork.Order(input);

            return Ok();
        }

        [HttpGet]
        public async Task<IReadOnlyList<Order>> Orders()
        {
            var test = _order.OrderedMovie();
            // var filter = _order.OrderedMovie(test.Result);
            return test.Result;
        }
    }
}
