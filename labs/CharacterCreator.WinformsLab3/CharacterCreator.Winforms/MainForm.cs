using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Business;
using CharacterCreator.Winforms;

namespace CharacterCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var character = new Character();
        }

        private bool DisplayConfirmation ( string message, string name )
        {
            var result = MessageBox.Show(message, name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            return result == DialogResult.OK;
        }

        void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (_character != null)
                if (!DisplayConfirmation("Are you sure you want to close?", "Close"))
                    e.Cancel = true;
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            CharacterForm child = new CharacterForm();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: save the character
            _character = child.Character;
        }
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            CharacterForm child = new CharacterForm();
            child.Character = _character;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO Save the character
            _character = child.Character;
        }

        private Character _character;

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (_character == null)     // Verify Character
                return;

            if (!DisplayConfirmation($"Are you sure you want to delete {_character.Name}?", "Delete"))
                return;

            //TODO: DELETE
            _character = null;
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
