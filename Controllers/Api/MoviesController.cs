using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using StudyLJ.DTO;
using StudyLJ.Models;

namespace StudyLJ.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }


        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return this._context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }


        //GET /api/movies/1
        public MovieDto GetMovie(int id)
        {
            var movie = this._context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movie,MovieDto>(movie);
        }


        //POST /api/movies
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto,Movie>(movieDto);
            this._context.Movies.Add(movie);
            this._context.SaveChanges();

            movieDto.Id = movie.Id;

            return movieDto;
        }


        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = this._context.Movies.FirstOrDefault(m =>m.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(movieDto,movieInDB);

            this._context.SaveChanges();
        }


        [HttpDelete]
        public void DeleteMoview(int id)
        {
            var movieInDB = this._context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            this._context.Movies.Remove(movieInDB);
            this._context.SaveChanges();
        }

    }
}
