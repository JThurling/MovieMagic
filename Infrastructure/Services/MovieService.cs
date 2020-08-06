using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Inputs;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MovieService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Movies>> MovieFunctions(Movies movies)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<Movies>> MovieUpdate(MovieInput movies)
        {
            if (movies == null) return null;

            var movieEdit = new Movies
            {
                Id = movies.Id,
                Genre = movies.Genre,
                Price = movies.Price,
                Title = movies.Title
            };

            _context.Movies.Update(movieEdit);
            await _context.SaveChangesAsync();

            return await _context.Movies.ToListAsync();
        }

        public async Task<IReadOnlyList<Movies>> MovieDelete(MovieInput movies)
        {
            if (movies == null) return null;

            var movieEdit = new Movies
            {
                Id = movies.Id,
                Genre = movies.Genre,
                Price = movies.Price,
                Title = movies.Title
            };

            _context.Movies.Remove(movieEdit);
            await _context.SaveChangesAsync();

            return await _context.Movies.ToListAsync();
        }

        public async Task<IReadOnlyList<Movies>> MovieFunctions(AddMovie movies)
        {
            if (movies == null)
                return null;

            var movieAdd = new Movies
            {
                Title = movies.Title,
                Genre = movies.Genre,
                Price = movies.Price
            };

            _context.Movies.Add(movieAdd);
            int result = await _context.SaveChangesAsync();

            if (result == 0) return null;

            return await _context.Movies.ToListAsync();
        }

        public async Task<IReadOnlyList<Movies>> MovieFunctions()
        {
            var movielist = await _context.Movies.ToListAsync();

            return movielist;
        }

        public async Task<Movies> GetMovie(Guid id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(movies => movies.Id == id );
            return movie;
        }
    }
}
