using AutoMapper;
using BonjoAPI.Entities;
using BonjoAPI.Models;
using BonjoAPI.Models.Movie;

namespace BonjoAPI.Others
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //User
            CreateMap<UserDTO, UserModel>();
            CreateMap<UserRegisterDTO, UserDTO>();
            CreateMap<UserUpdateDTO, UserDTO>();

            //Movies
            CreateMap<MovieDTO, MovieModel>();
            CreateMap<MovieRegisterDTO, MovieDTO>();
            CreateMap<MovieUpdateDTO, MovieDTO>();
        }
    }
}