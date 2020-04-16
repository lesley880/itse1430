using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;
using MovieLibrary.Business.FileSystem;
using MovieLibrary.Business.Memory;
using MovieLibrary.Business.SqlServer;
using MovieLibrary.Winforms;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            // MovieLibrary.Business.Movie;
            //var movie = new Movie();

            //movie.title = "Jaws";
            //movie.description = movie.title;

            //movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);

            //DisplayConfirmation("Are you sure?", "Start");
        }

        private bool DisplayConfirmation(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            return result == DialogResult.OK;
        }

        void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //var that = this;

            //var Text = "";
            //var newTitle = this.Text;
            //var newTitle = Text;
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad(e);

            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _movies = new SqlMovieDatabase(connString.ConnectionString);

            // SeedDatabase.SeedIfEmpty(_movies);

            // call extention method as though it is an instance; discover it.
            //try
            //{
            //    _movies.SeedIfEmpty();
            //} catch (InvalidOperationException)
            //{
            //    DisplayError("Invalid op");
            //}catch(ArgumentException)
            //{
            //    DisplayError("Invalid Argument");
            //}catch(Exception ex)
            //{
            //    DisplayError(ex.Message);
            //}
            UpdateUI();
        }

        void DisplayMovie (Movie movie)
        {
            if (movie == null)
                return;

            var title = movie.Title;
            movie.Description = "Test";

            movie = new Movie();
        }

       
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            MovieForm child = new MovieForm();
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                
                var movie = _movies.Add(child.Movie);
                if (movie != null)
                {
                    UpdateUI();
                    return;
                }

                DisplayError("Add failed");
            } while (true);
        }

        // private string SortByTitle ( Movie movie ) => movie.Title;
        // private int SortByReleaseYear ( Movie movie ) => movie.ReleaseYear;

        private void UpdateUI ()
        {
            listMovies.Items.Clear();

            var movies = Enumerable.Empty<Movie>();
            try
            {
                movies = _movies.GetAll();
            } catch (Exception e)
            {
                DisplayError($"Failed to load movies: {e.Message}");
            }

            //Linq
            movies = from movie in movies
                         where movie.Id > 0
                         orderby movie.Title, movie.ReleaseYear descending
                         select movie;
            // Error handleling = try catch block
            // try
            // { s*}
            // catch
            // {S* }
            //
            //
            //
            

            // extention
            //var movies = _movies.GetAll()
            //                    .OrderBy(movie => movie.Title)
            //                    .ThenByDescending(movie => movie.ReleaseYear);

            listMovies.Items.AddRange(movies.ToArray());

            //foreach (var movie in movies)
            //{
            //    listMovies.Items.Add(movie);
            //}
        }

        private Movie GetSelectedMovie ()
        {
            // preferred
            //return listMovies.SelectedItem as Movie;

            var selectedItems = listMovies.SelectedItems.OfType<Movie>();
            return selectedItems.FirstOrDefault();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.Movie = movie;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                // Save the movie
                var error = _movies.Update(movie.Id, child.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            // Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            // Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {movie.Title}?", "Delete"))
                return;

            //TODO: DELETE
            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }
        private IMovieDatabase _movies;

    }
}