using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Inputs;

namespace Core.Interfaces
{
    public interface IMovieService
    {
        public Task<IReadOnlyList<Movies>> MovieFunctions(Movies movies);
        public Task<IReadOnlyList<Movies>> MovieUpdate(MovieInput movies);
        public Task<IReadOnlyList<Movies>> MovieDelete(MovieInput movies);
        public Task<IReadOnlyList<Movies>> MovieFunctions(AddMovie movies);
        public Task<IReadOnlyList<Movies>> MovieFunctions();

        public Task<Movies> GetMovie(Guid id);
    }
}
