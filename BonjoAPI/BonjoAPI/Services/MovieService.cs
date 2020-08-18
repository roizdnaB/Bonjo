using BonjoAPI.Entities;
using BonjoAPI.Others;
using BonjoAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BonjoAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext dataContext;

        public MovieService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public MovieEntity Create(MovieEntity movie)
        {
            if (dataContext.Movies.Any(x => x.Title == movie.Title))
                throw new Exception($"Movie '{movie.Title}' is already in the database!");

            dataContext.Movies.Add(movie);
            dataContext.SaveChanges();

            return movie;
        }

        public void Delete(int id)
        {
            var movie = dataContext.Movies.Find(id);
            if (movie != null)
            {
                dataContext.Movies.Remove(movie);
                dataContext.SaveChanges();
            }
        }

        public IEnumerable<MovieEntity> GetAll() => dataContext.Movies;

        public MovieEntity GetById(int id) => dataContext.Movies.Find(id);

        public void Update(MovieEntity movie)
        {
            var updateMovie = dataContext.Movies.Find(movie.ID);

            if (movie == null)
                throw new Exception("Movie not found");

            if (!string.IsNullOrWhiteSpace(movie.Title) && movie.Title != updateMovie.Title)
            {
                if (dataContext.Movies.Any(x => x.Title == movie.Title))
                    throw new Exception($"Movie '{movie.Title}' is already in the database!");

                updateMovie.Title = movie.Title;
            }

            dataContext.Movies.Update(updateMovie);
            dataContext.SaveChanges();
        }
    }
}