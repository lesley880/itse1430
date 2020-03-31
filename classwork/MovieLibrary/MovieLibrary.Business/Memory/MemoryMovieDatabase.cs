using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {
            //TODO: Clone movie to store
            var item = CloneMovie(movie);
            item.Id = _id++;
            _movies.Add(item);

            return CloneMovie(item);
        }

        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);
        }

        protected override Movie GetCore (int id)
        {
            var movie = FindById(id);
            if (movie == null)
                return null;

            return CloneMovie(movie);
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            foreach (var movie in _movies)
            {
                yield return CloneMovie(movie);
            }
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);

            //Update
            CopyMovie(existing, movie, false);
        }

        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            CopyMovie(item, movie, true);

            return item;

            // object initializer syntax
            //return new Movie() {
            //    Id = movie.Id,
            //    Title = movie.Title,
            //    Description = movie.Description,
            //    Genre = new Genre(movie.Genre.Description),
            //    IsClassic = movie.IsClassic,
            //    ReleaseYear = movie.ReleaseYear,
            //    RunLength = movie.RunLength,
            //};
        }

        private void CopyMovie ( Movie target, Movie source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            if (source.Genre != null)
                target.Genre = new Genre(source.Genre.Description);
            else
                target.Genre = null;
            target.IsClassic = source.IsClassic;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
        }

        protected override Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie?.Title, title, true) == 0)
                    return movie;
            }

            return null;
        }

        //private bool IsId ( Movie movie ) => movie.Id == id;

        protected override Movie FindById ( int id ) // => _movies.FirstOrDefault(IsId);
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            }

            return null;
        }

// private readonly Movie[] _movies = new Movie[100];
private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
