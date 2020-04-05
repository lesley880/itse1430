using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Lesley Reller
 * ITSE 1430
 * 02/16/2020
 */

namespace CharacterCreator.Business
{
    public class Character
    {
        public Profession Profession { get; set; }

        public Race Race { get; set; }

        public int Id { get; set; }

        public string Name                       
        {
            get => _name??"";                   
            set =>_name = value?.Trim();
        }
        private string _name;                    

        public int Strength { get; set; } = 50;

        public int Intelligence { get; set; } = 50;

        public int Wisdom { get; set; } = 50;

        public int Dexterity { get; set; } = 50;

        public int Constitution { get; set; } = 50;

        public string Description
        {
            get => _description ?? "";    
            set => _description = value?.Trim();
        }
        private string _description;

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            // Name i srequired
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required.", new[] { nameof(Name) });
            };

            // is profession empty
            if (Profession == null)
            {
                yield return new ValidationResult("Profession required", new[] { nameof(Profession) });
            }

            if (Race == null)
            {
                yield return new ValidationResult("Race required", new[] { nameof(Race) });
            }

            if (Strength < 1 || Strength > 100)
            {
                yield return new ValidationResult("Strength must be between 1 and 50.", new[] { nameof(Strength) });
            }

            if (Intelligence < 1 || Intelligence > 100)
            {
                yield return new ValidationResult("Intelligence must be between 1 and 50.", new[] { nameof(Intelligence) });
            }

            if (Wisdom < 1 || Wisdom > 100)
            {
                yield return new ValidationResult("Wisdom must be between 1 and 50.", new[] { nameof(Wisdom) });
            }

            if (Dexterity < 1 || Dexterity > 100)
            {
                yield return new ValidationResult("Dexterity must be between 1 and 50.", new[] { nameof(Dexterity) });
            }

            if (Constitution < 1 || Constitution > 100)
            {
                yield return new ValidationResult("Constitution must be between 1 and 50..", new[] { nameof(Constitution) });
            }

        }

        //public bool Validate ( out string error )
        //{
        //    if (String.IsNullOrEmpty(Name))
        //    {
        //        error = "Name is required.";
        //        return false;
        //    }

        //    if (Profession == null)
        //    {
        //        error = "Profession is required.";
        //        return false;
        //    }

        //    if (Race == null)
        //    {
        //        error = "Race is required.";
        //        return false;
        //    }

        //    if (Strength < 1 || Strength > 100)
        //    {
        //        error = "Strength must be between 1 and 100.";
        //        return false;
        //    }

        //    if (Intelligence < 1 || Intelligence > 100)
        //    {
        //        error = "Intelligence must be between 1 and 100.";
        //        return false;
        //    }

        //    if (Wisdom < 1 || Wisdom > 100)
        //    {
        //        error = "Wisdom must be between 1 and 100.";
        //        return false;
        //    }

        //    if (Dexterity < 1 || Dexterity > 100)
        //    {
        //        error = "Dexterity must be between 1 and 100.";
        //        return false;
        //    }

        //    if (Constitution < 1 || Constitution > 100)
        //    {
        //        error = "Constitution must be between 1 and 100.";
        //        return false;
        //    }

        //    error = null;
        //    return true;
        //}
    }
}
