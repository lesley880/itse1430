using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;
using MovieLibrary.Winforms;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            // MovieLibrary.Business.Movie;
            var movie = new Movie();

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

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO Save the movie
            AddMovie(child.Movie);
            UpdateUI();
        }

        private void UpdateUI ()
        {
            listMovies.Items.Clear();
            var movies = GetMovies();
            foreach (var movie in movies)
            {
                if(movie != null)
                listMovies.Items.Add(movie);
            }
        }

        private void AddMovie ( Movie movie )
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index] == null)
                {
                    _movies[index] = movie;
                    break;
                }
            }
        }

        private Movie[] GetMovies ()
        {
            return _movies;
        }

        private Movie GetSelectedMovie ()
        {
            return listMovies.SelectedItem as Movie;
        }

        private void UpdateMovie(Movie oldMovie, Movie newMovie)
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if(_movies[index] == oldMovie)
                {
                    _movies[index] = newMovie;
                    break;
                }
            }
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            // Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            MovieForm child = new MovieForm();
            child.Movie = movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO Save the movie
            UpdateMovie(movie, child.Movie);
            UpdateUI();
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
            DeleteMovie(movie);
            UpdateUI();
        }

        private void DeleteMovie (Movie movie)
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index] == movie)
                {
                    _movies[index] = null;
                    break;
                }
            }
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

        //private Movie _movie;
        private Movie[] _movies = new Movie[100];
    }
}