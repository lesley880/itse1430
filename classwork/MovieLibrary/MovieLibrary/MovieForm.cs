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
        public MovieForm ()
        {
            InitializeComponent();
        }

        private void MovieForm_Load ( object sender, EventArgs e )
        {

        }

        public Movie Movie;

        private void OnOK ( object sender, EventArgs e )
        {
            //TODO: Validation and error reporting.
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            //TODO: Validation and error reporting.
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
