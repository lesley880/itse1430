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
                                                           // => _movies.FirstOrDefault(m => String.Compare(m?.Title, title, true) == 0);   //extention
       
        //{
        //    foreach (var movie in _movies)
        //    {
        //        if (String.Compare(movie?.Title, title, true) == 0)
        //            return movie;
        //    }

        //    return null;
        //}

        //private bool IsId ( Movie movie ) => movie.Id == id;

        protected override Movie FindById ( int id ) => _movies.FirstOrDefault(m => m.Id == id);
        //{
        //    _movies.FirstOrDefault( m => m.Id == id);       // lambda aka anonymous function ( m => m.Id == id )

        //    foreach (var movie in _movies)
        //    {
        //        if (movie.Id == id)
        //            return movie;
        //    }

        //    return null;
        //}

        // private readonly Movie[] _movies = new Movie[100];
        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;

        //private bool _@FAk2Fa235 ( Movie movie ) { return movie.Id == id; }

        //Lambda syntax ::= parameters => body
        // 0 parameters () => ?     Func<?>
        // 1 parameter, 1 return type ::=   x => E   ,  _ => E         Func<T, ?>
        // 2+ parameters (x,y) => ?                                    Func<S, T, ?>
        // no return type => {}                                        Action<>
        // Multiple statement expressions => { S* }
        //      x => { Console.WriteLine(x); var y = x; return x; }
        //
        // General rules around lambdas
        //   1. No ref or out parameters
        //   2. Closure - any changes to capture values are lost
    }
}
