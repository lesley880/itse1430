using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLibrary.Business.SqlServer
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // add parameters
                //1. Long way
                var pName = new SqlParameter("@name", movie.Title);
                cmd.Parameters.Add(pName);
                //2. short way
                var pGenre = cmd.Parameters.Add("@genre", System.Data.SqlDbType.NVarChar);
                if (movie.Genre != null)
                    pGenre.Value = movie.Genre.Description;
                //3. short way

                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                // Executes the command returns back the first value of the first row
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                movie.Id = id;

                return movie;
            }
        }

        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                // ignore return value
                cmd.ExecuteNonQuery();
            }
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var items = new List<Movie>();

            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetMovies";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Intermediary
                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                // populate data
                da.Fill(ds);
            }

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault(); // IEnumerable -> IEnumerable <T>
            if (table != null)
            {
                // reading data using dataset
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var movie = new Movie() {
                        Id = Convert.ToInt32(row[0]),               // row object ordinal
                        Title = row["Name"]?.ToString(),            // row object with column name
                        Description = row.Field<string>(2),         // Field Method with type and ordinl
                        //Genre = row.Field<string>("Genre"),
                        ReleaseYear = row.Field<int>("ReleaseYear"),// feild mehtod with type and column name
                        RunLength = row.Field<int>("RunLength"),
                        IsClassic = row.Field<bool>("IsClassic")
                    };

                    // DBNull.Vlaue
                    var genre = !row.IsNull("Genre") ? row.Field<string>("Genre") : null;
                    if (!String.IsNullOrEmpty(genre))
                        movie.Genre = new Genre(genre);

                    items.Add(movie);
                };
            }

            return items;
        }

        private SqlConnection OpenConnection ()
        {
            //DbConnection
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateMovie", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                // add parameters
                //1. Long way
                var pName = new SqlParameter("@name", movie.Title);
                cmd.Parameters.Add(pName);
                //2. short way
                var pGenre = cmd.Parameters.Add("@genre", System.Data.SqlDbType.NVarChar);
                if (movie.Genre != null)
                    pGenre.Value = movie.Genre.Description;
                //3. short way

                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                // Executes the command returns back the first value of the first row
                cmd.ExecuteNonQuery();
            }
        }

        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "FindByName";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", title);

                // Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie() {
                            Id = Convert.ToInt32(reader[0]),                // Dictionary with zero based ordinal
                            Title = reader["Name"]?.ToString(),             // Dictionary with column name
                            Description = reader.GetString(2),              // GetType ordinal
                            ReleaseYear = reader.GetFieldValue<int>(4),     // Generic (ordinal)
                            RunLength = reader.GetFieldValue<int>(5),
                            IsClassic = reader.GetBoolean(6)
                        };

                        // DBNull.Vlaue
                        var ordinal = reader.GetOrdinal("Genre");
                        var genre = !reader.IsDBNull(ordinal) ? reader.GetFieldValue<string>(ordinal) : null;
                        if (!String.IsNullOrEmpty(genre))
                            movie.Genre = new Genre(genre);

                        return movie;
                    };
                };
            };

            return null;
        }

        protected override Movie FindById ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                // Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie() {
                            Id = Convert.ToInt32(reader[0]),                // Dictionary with zero based ordinal
                            Title = reader["Name"]?.ToString(),             // Dictionary with column name
                            Description = reader.GetString(2),              // GetType ordinal
                            ReleaseYear = reader.GetFieldValue<int>(4),     // Generic (ordinal)
                            RunLength = reader.GetFieldValue<int>(5),
                            IsClassic = reader.GetBoolean(6)
                        };

                        // DBNull.Vlaue
                        var ordinal = reader.GetOrdinal("Genre");
                        var genre = !reader.IsDBNull(ordinal) ? reader.GetFieldValue<string>(ordinal) : null;
                        if (!String.IsNullOrEmpty(genre))
                            movie.Genre = new Genre(genre);

                        return movie;
                    };
                };
            };

            return null;
        }

        protected override Movie GetCore ( int id ) => FindById(id);

        private readonly string _connectionString;
    }
}
