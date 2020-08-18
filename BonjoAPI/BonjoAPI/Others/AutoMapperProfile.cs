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
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserRegisterModel, UserEntity>();
            CreateMap<UserUpdateModel, UserEntity>();

            //Movies
            CreateMap<MovieEntity, MovieModel>();
            CreateMap<MovieRegisterModel, MovieEntity>();
            CreateMap<MovieUpdateModel, MovieEntity>();
        }
    }
}