using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie is null");
            //return null;

            //.NET validation
            ObjectValidator.Validate(movie);

            //Movie names must be unique
            try
            {
                var existing = FindByTitle(movie.Title);
                if (existing != null)
                    throw new InvalidOperationException("Movie must be unique");

                return AddCore(movie);
            } catch (InvalidOperationException)
            {
                //Rethrow exception
                throw;
            } catch (Exception e)
            {
                //Rewrite exception with original exception as the inner exception
                throw new InvalidOperationException("Error adding movie", e);
            };
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            try
            {
                DeleteCore(id);
            } catch (Exception e)
            {
                //Rewrite exception
                throw new InvalidOperationException("Error deleting movie.", e);
            };
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            try
            {
                return GetCore(id);
            } catch (Exception e)
            {
                //Rewrite exception
                throw new InvalidOperationException("Error reading movie.", e);
            };
        }

        protected abstract Movie GetCore ( int id );

        public IEnumerable<Movie> GetAll ()
        {
            try
            {
                return GetAllCore() ?? Enumerable.Empty<Movie>();
            } catch (Exception e)
            {
                //Rewrite exception
                throw new InvalidOperationException("Error reading movies.", e);
            };
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        //private sealed class Enumerator<T> : IEnumerator<T>
        //{
        //    ...
        //}

        //TODO: Validate
        //TODO: Movie names must be unique
        //TODO: Clone movie to store
        public void Update ( int id, Movie movie )
        {
            //if (movie == null)
            //  return "Movie is null";
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie is null");

            ObjectValidator.Validate(movie);

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            //return "Id is invalid";

            try
            {
                var existing = FindById(id);
                if (existing == null)
                    throw new ArgumentException("Movie not found", nameof(id));

                //Movie names must be unique
                var sameName = FindByTitle(movie.Title);
                if (sameName != null && sameName.Id != id)
                    throw new InvalidOperationException("Movie must be unique");

                UpdateCore(id, movie);
            } catch (ArgumentException)
            {
                //Rethrow exception
                throw;
            } catch (InvalidOperationException)
            {
                //Rethrow exception
                throw;
            } catch (Exception e)
            {
                //Rewrite exception
                throw new InvalidOperationException("Error updating movie.", e);
            };
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );

        protected abstract Movie FindById ( int id );
    }
}
