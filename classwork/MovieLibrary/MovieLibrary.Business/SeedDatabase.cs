﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{
    public static class SeedDatabase
    {
        public static IMovieDatabase SeedIfEmpty ( this IMovieDatabase database )
        {
            if (!database.GetAll().Any())
            {
                //Collection initializer - works with anything with an Add method
                var demo = new Movie() { Title = "Dune", RunLength = 260, ReleaseYear = 1985 };
                var items = new[] {
                    new Movie() { Title = "Jaws", RunLength = 210, ReleaseYear = 1977 },
                    new Movie() { Title = "Jaws 2", RunLength = 220, ReleaseYear = 1979 },
                    demo,
                };

                //var movie = new Movie();
                //movie.Title = "Jaws";
                //movie.RunLength = 210;
                foreach (var item in items)
                    database.Add(item);
            };

            return database;
        }
    }
}