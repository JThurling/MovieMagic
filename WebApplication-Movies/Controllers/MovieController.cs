using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Inputs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Movies.Attributes;
using WebApplication_Movies.Dto;

namespace WebApplication_Movies.Controllers
{
    [Authorization("Admin")]
    public class MovieController : BaseApiController
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public IReadOnlyList<MovieDto> GetMovieList()
        {
            var movieList = _movieService.MovieFunctions();

            return _mapper.Map<IReadOnlyList<Movies>, IReadOnlyList<MovieDto>>(movieList.Result);
        }

        [HttpGet("{id}")]
        public async Task<MovieDto> GetMovie(Guid id)
        {
            var movie = await _movieService.GetMovie(id);
            return _mapper.Map<Movies, MovieDto>(movie);
        }

        [HttpPost]
        public IReadOnlyList<MovieDto> AddMovies(AddMovie movie)
        {
            var listWithAddedMovies = _movieService.MovieFunctions(movie);

            return _mapper.Map<IReadOnlyList<Movies>, IReadOnlyList<MovieDto>>(listWithAddedMovies.Result);
        }

        [HttpPut("edit")]
        public async Task<IReadOnlyList<MovieDto>> EditMovie(MovieInput movie)
        {
            var editedMovie = await _movieService.MovieUpdate(movie);
            return _mapper.Map<IReadOnlyList<Movies>, IReadOnlyList<MovieDto>>(editedMovie);
        }

        [HttpPost("delete")]
        public async Task<IReadOnlyList<MovieDto>> DeleteMovie(MovieInput movie)
        {
            // var authorized = AuthCheck(user.Role);
            // if (!authorized) return "Unauthorized!";

            var deletedMovie = await _movieService.MovieDelete(movie);
            return _mapper.Map<IReadOnlyList<Movies>, IReadOnlyList<MovieDto>>(deletedMovie);
        }


        private bool AuthCheck(string inputRole)
        {
            var roles = typeof(AccountController).GetCustomAttributes(
                typeof(AuthorizationAttribute), true).Cast<AuthorizationAttribute>().Select(
                x => x.Role);

            foreach (var role in roles)
            {
                if (role.ToLower() == inputRole.ToLower()) return true;
            }

            return false;
        }
    }
}
