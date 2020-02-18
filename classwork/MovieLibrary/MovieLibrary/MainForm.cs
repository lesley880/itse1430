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

        /// <summary>Displays an error message.</summary>
        /// <param name= "message"Error to display></param>
        /// 
        void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //var that = this;

            //var Text = "";
            //var newTitle = this.Text;
            //var newTitle = Text;
        }

        void DisplayMovie(Movie movie)
        {
            if (movie == null)
                return;

            var title = movie.Title;
            movie.Description = "Test";

            movie = new Movie();
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (_movie != null)
                if (!DisplayConfirmation("Are you sure you want to close?", "Close"))
                    e.Cancel = true;
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            MovieForm child = new MovieForm();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;
            //TODO Save the movie
            _movie = child.Movie;
            //show child
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            // Verify movie
            if (_movie == null)
                return;

            MovieForm child = new MovieForm();
            child.Movie = _movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO Save the movie
            _movie = child.Movie;
        }

        private Movie _movie;

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            // Verify movie
            if (_movie == null)
                return;

            // Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {_movie.Title}?", "Delete"))
                return;

            //TODO: DELETE
            _movie = null;
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
    }
}