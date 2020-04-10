using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                throw new ArgumentNullException(nameof(Movie), "Movie is null.");
                //return null;

            // .Net
            ObjectValidator.Validate(movie);
            //if (errors.Any())
                //if (!Validator.TryValidateObject(movie, new ValidationContext(movie), errors, true))
                //if (!movie.Validate(out var error))
                //return null;

            // Movie Names must be unique
            var exsisting = FindByTitle(movie.Title);
            if (exsisting != null)
                throw new InvalidOperationException("Movie must be unique");
            return AddCore(movie);
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <=0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get (int id)
        {
            //TODO: error
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        public IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty <Movie>(); 

        protected abstract IEnumerable<Movie> GetAllCore();

        public string Update ( int id, Movie movie )
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(Movie), "Movie is null.");
            //return "Movie is null";

            ObjectValidator.Validate(movie);

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be grater than zero");
                //return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                throw new ArgumentException("Movie not found", nameof(id));
               //return "Movie not found";

            //Movie names must be unique
            var sameName = FindByTitle(movie.Title);
            if (sameName != null && sameName.Id != id)
                throw new InvalidOperationException("Movie must be unique");
               // return "Movie must be unique";

            UpdateCore(id, movie);

            return null;
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );

        protected abstract Movie FindById ( int id );
    }
}
