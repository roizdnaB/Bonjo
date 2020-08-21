using BonjoAPI.Entities;
using System.Collections.Generic;

namespace BonjoAPI.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieDTO> GetAll();

        MovieDTO GetById(int id);

        MovieDTO Create(MovieDTO movie);

        void Update(MovieDTO movie);

        void Delete(int id);
    }
}