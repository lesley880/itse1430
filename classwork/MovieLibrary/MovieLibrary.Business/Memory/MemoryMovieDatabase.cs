using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // filtering
            var items = _movies.Where(m => true);

            // Transformations
            return _movies.Select(m => CloneMovie(m));

            //Debug.WriteLine("Starting GetAllCore");

            //foreach (var movie in _movies)
            //{
            //    Debug.WriteLine($"Returning {movie.Id}");
            //    yield return CloneMovie(movie);
            //    Debug.WriteLine($"Returned {movie.Id}");
            //}
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

        // example of doing more complex quering with programmatic filters
        //private IEnumerable<Movie> Query ( string title, int releaseYear )
        //{
        //    var query = from movie in _movies
        //                select movie;

        //    if (!String.IsNullOrEmpty(title))
        //        query = query.Where(m => String.Compare(m.Title, title, true) == 0);

        //    if (releaseYear > 0)
        //        query = query.Where(m => m.ReleaseYear >= releaseYear);
        //    return query.ToList();
        //}

        protected override Movie FindByTitle ( string title ) => (from movie in _movies                                 // linq
                                                                 where String.Compare(movie.Title, title, true) == 0
                                                                 select movie).FirstOrDefault();
        protected override Movie FindById ( int id ) => _movies.FirstOrDefault(m => m.Id == id);

        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
