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

/*
 * Lesley Reller
 * ITSE 1430
 * 03/26/2020
 */

namespace CharacterCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _characters = new MemoryCharacterDatabase();
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

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            _characters.SeedIfEmpty();

            UpdateUI();
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            CharacterForm child = new CharacterForm();
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
               
                var movie = _characters.Add(child.Character);
                if (movie != null)
                {
                    UpdateUI();
                    return;
                }

                DisplayError("Add failed");
            } while (true);
        }

        private void UpdateUI ()
        {
            listCharacters.Items.Clear();

            var characters = from character in _characters.GetAll()     // Linq method
                             where character.Id > 0
                             orderby character.Name descending
                             select character;

            listCharacters.Items.AddRange(characters.ToArray());
        }

        private Character GetSelectedCharacter ()
        {
            return listCharacters.SelectedItem as Character;
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var child = new CharacterForm();
            child.Character = character;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                // Save

                var error = _characters.Update(character.Id, child.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error);
            } while (true);
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            // Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "Delete"))
                return;

            //TODO: DELETE
            _characters.Delete(character.Id);
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
        private readonly ICharacterDatabase _characters;
    }
}
