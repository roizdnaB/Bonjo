using AutoMapper;
using BonjoAPI.Entities;
using BonjoAPI.Models.Movie;
using BonjoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BonjoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] MovieRegisterDTO movieRegisterModel)
        {
            var movie = mapper.Map<MovieDTO>(movieRegisterModel);

            try
            {
                movieService.Create(movie);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = mapper.Map<IList<MovieModel>>(movieService.GetAll());

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = mapper.Map<MovieModel>(movieService.GetById(id));

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MovieUpdateDTO movieUpdateModel)
        {
            var movie = mapper.Map<MovieDTO>(movieUpdateModel);
            movie.ID = id;

            try
            {
                movieService.Update(movie);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            movieService.Delete(id);
            return Ok();
        }
    }
}