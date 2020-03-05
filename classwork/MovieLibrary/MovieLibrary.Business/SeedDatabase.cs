using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class SeedDatabase
    {
        public IMovieDatabase SeedIfEmpty (IMovieDatabase database)
        {
            if (database.GetAll().Length ==0 )
            {
                database.Add(new Movie() { Title = "Jaws", RunLength = 220, ReleaseYear = 1977});
                database.Add(new Movie() { Title = "Jaws 2", RunLength = 210, ReleaseYear = 1980 });
                database.Add(new Movie() { Title = "Star Wars", RunLength = 210, ReleaseYear = 2010 });
            }
            return database;
        }
    }
}
