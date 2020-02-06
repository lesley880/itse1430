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

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            // MovieLibrary.Business.Movie;
            var movie = new Movie();

            movie.title = "Jaws";
            movie.description = movie.title;

            movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);

            DisplayConfirmation("Are you sure?", "Start");
        }

        private bool DisplayConfirmation(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            return result == DialogResult.OK;
        }

        /// <summary>Displays an error message.</summary>
        /// <param name="message"Error to display></param>
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

            var title = movie.title;
            movie.description = "Test";

            movie = new Movie();
        }
    }
}