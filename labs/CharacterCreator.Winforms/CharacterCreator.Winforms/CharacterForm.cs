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

/*
 * Lesley Reller
 * ITSE 1430
 * 03/26/2020
 */

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public CharacterForm ( Character character ) : this(character != null ? "Edit" : "Add", character)
        {
            
        }

        public CharacterForm ( string name, Character character ) : this()
        {
            Text = name;
            Character = character;
        }

        public Character Character { get; set; }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnOK ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            //TODO: vALIDATE and error reporting
            var character = GetCharacter();
            var errors = ObjectValidator.Validate(character);

            if (errors.Any())
            {
                DisplayError("Error");
                return;
            }

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            var profession = Professions.GetAll();
            var race = Races.GetAll();

            ddlProfession.Items.AddRange(profession);
            ddlRace.Items.AddRange(race);

            if (Character != null)
            {
                txtName.Text = Character.Name;
                txtStrength.Text = Character.Strength.ToString();
                txtIntelligence.Text = Character.Intelligence.ToString();
                txtWisdom.Text = Character.Wisdom.ToString();
                txtDexterity.Text = Character.Dexterity.ToString();
                txtConstitution.Text = Character.Constitution.ToString();
                txtDescription.Text = Character.Description;

                if (Character.Profession != null)
                    ddlProfession.Text = Character.Profession.Description;
                if (Character.Race != null)
                    ddlRace.Text = Character.Race.Description;
            };
        }

        private Character GetCharacter ()
        {
            var character = new Character();

            character.Name = txtName.Text?.Trim();
            character.Strength = GetAsInt32(txtStrength, 50);
            character.Intelligence = GetAsInt32(txtIntelligence, 50);
            character.Wisdom = GetAsInt32(txtWisdom, 50);
            character.Dexterity = GetAsInt32(txtDexterity, 50);
            character.Constitution = GetAsInt32(txtConstitution, 50);
            character.Description = txtDescription.Text.Trim();

            if (ddlProfession.SelectedItem is Profession profession)        
                character.Profession = profession;
            if (ddlRace.SelectedItem is Race race)
                character.Race = race;

            return character;
        }

        void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetAsInt32 ( Control control, int emptyValue )
        {
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStrength ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0 || value > 100)
            {
                _errors.SetError(control, "Must be between 1 and 50.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateIntelligence ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0 || value > 100)
            {
                _errors.SetError(control, "Must be between 1 and 50.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateWisdom ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0 || value > 100)
            {
                _errors.SetError(control, "Must be between 1 and 50.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateDexterity ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0 || value > 100)
            {
                _errors.SetError(control, "Must be between 1 and 50.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateConstitution ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0 || value > 100)
            {
                _errors.SetError(control, "Must be between 1 and 50.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
