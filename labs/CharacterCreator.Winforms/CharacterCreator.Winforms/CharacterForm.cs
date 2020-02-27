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
            //TODO: vALIDATE
            var character = GetCharacter();
            if (!character.Validate(out var error))
            {
                DisplayError(error);
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
                Strength.Text = Character.Strength.ToString();
                txt.Text = Character.Intelligence.ToString();
                Wisdom.Text = Character.Wisdom.ToString();
                Dexterity.Text = Character.Dexterity.ToString();
                txtC.Text = Character.Constitution.ToString();
                txtDescription.Text = Character.Description;

                if (Character.Profession != null)
                    ddlProfession.SelectedText = Character.Profession.Description;
                if (Character.Race != null)
                    ddlRace.SelectedText = Character.Profession.Description;
            };
        }

        private Character GetCharacter ()
        {
            var character = new Character();

            character.Name = txtName.Text?.Trim();
            character.Strength = GetAsInt32(Strength);
            character.Intelligence = GetAsInt32(txt);
            character.Wisdom = GetAsInt32(Wisdom);
            character.Dexterity = GetAsInt32(Dexterity);
            character.Constitution = GetAsInt32(txtC);
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

        private int GetAsInt32 ( Control control )
        {
            return GetAsInt32(control, 0);
        }

        private int GetAsInt32 ( Control control, int emptyValue )
        {
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }
    }
}
