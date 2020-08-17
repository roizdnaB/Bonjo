using BonjoAPI.Entities;
using System.Collections.Generic;

namespace BonjoAPI.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieEntity> GetAll();

        MovieEntity GetById(int id);

        MovieEntity Create(MovieEntity movie);

        void Update(MovieEntity movie);

        void Delete(int id);
    }
}