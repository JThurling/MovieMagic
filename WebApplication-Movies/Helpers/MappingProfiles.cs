using AutoMapper;
using Core.Entities;
using Core.Inputs;
using WebApplication_Movies.Dto;

namespace WebApplication_Movies.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movies, MovieDto>();
            CreateMap<Users, User>();
        }
    }
}
