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

namespace MovieLibrary.Winforms
{
    public partial class MovieForm : Form
    {
        public MovieForm () //: base()
        {
            InitializeComponent();
        }

        // Call the more specific constructor first - constructor chaining
        public MovieForm ( Movie movie ) : this(movie != null ? "Edit" : "Add", movie)
        {
            //InitializeComponent();
            //Movie = movie;
            //Text = movie != null ? "Edit" : "Add";
        }

        public MovieForm ( string title, Movie movie ) : this()
        {
            Text = title;
            Movie = movie;
        }

        public Movie Movie { get; set; }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnOK ( object sender, EventArgs e ) 
        {
            if (!ValidateChildren())
                return;

            //TODO: Validation and error reporting.
            var movie = GetMovie();
            if (!movie.Validate(out var error))
            {
                DisplayError(error);
                return;
            }

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad(e);

            // Populate combo
            var genres = Genres.GetAll();

            ddlGenres.Items.AddRange(genres);

            if (Movie != null)
            {
                txtTitle.Text= Movie.Title;
                txtDescription.Text = Movie.Description;
                txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                txtRunLength.Text = Movie.RunLength.ToString();
                chkIsClassic.Checked = Movie.IsClassic;

                if (Movie.Genre != null)
                    ddlGenres.SelectedText = Movie.Genre.Description;

                ValidateChildren();
            }
        }

        private Movie GetMovie ()
        {
            var movie = new Movie();

            // Null Conditional -text property will ever return null, no string property will EVER return null.
            movie.Title = txtTitle.Text?.Trim();
            movie.RunLength = GetAsInt32(txtRunLength);
            movie.ReleaseYear = GetAsInt32(txtReleaseYear, 1900);
            movie.Description = txtDescription.Text.Trim();
            movie.IsClassic = chkIsClassic.Checked;

            //movie.Genre = (Genre)ddlGenres.SelectedItem;      //C-style, crashes if wrong

            //var genre = ddlGenres.SelectedItem as Genre;      //Preferred - as operator
            //if (genre != null)        
            //    movie.Genre = genre;

            //if (ddlGenres.SelectedItem is Genre)              // Equivalent of as
            //    genre = (Genre)ddlGenres.SelectedItem;

            if (ddlGenres.SelectedItem is Genre genre)         //Pattern match
                movie.Genre = genre;

            return movie;
        }

        void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetAsInt32 ( Control control )
        {
            return GetAsInt32(control, 0);
        }

        private int GetAsInt32( Control control, int emptyValue )
        {
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //DisplayError("Title is required.");
                _errors.SetError(control, "Title is required.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateRunLngth ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if(value < 0)
            {
                _errors.SetError(control, "Run length must be >= 0.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 1900);
            if (value < 1900)
            {
                _errors.SetError(control, "Release year must be >= 1900.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
