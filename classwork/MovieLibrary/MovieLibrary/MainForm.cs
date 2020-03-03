﻿using System;
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
            _movies.Add(child.Movie);
            UpdateUI();
        }

        private void UpdateUI ()
        {
            listMovies.Items.Clear();
            var movies = _movies.GetAll();
            foreach (var movie in movies)
            {
                listMovies.Items.Add(movie);
            }
        }

        private Movie GetSelectedMovie ()
        {
            return listMovies.SelectedItem as Movie;
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
            _movies.Update(movie, child.Movie);
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
            _movies.Delete(movie);
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

        private MovieDatabase _movies = new MovieDatabase();
    }
}