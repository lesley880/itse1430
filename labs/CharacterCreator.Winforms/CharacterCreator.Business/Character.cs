﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Business
{
    public class Character
    {
        public Profession Profession { get; set; }

        public Race Race { get; set; }

        public string Name                       // Property
        {
            get { return _name??""; }            // name doesnt have space at end
            set { _name = value?.Trim(); }
        }
        private string _name;                    // field

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public string Description
        {
            get { return _description??""; }     
            set { _description = value?.Trim(); }
        }
        private string _description;

        public bool Validate ( out string error )
        {
            if (String.IsNullOrEmpty(Name))
            {
                error = "Name is required.";
                return false;
            }

            //if (String.IsNullOrEmpty(Race))
            //{
            //    error= "Race is required.";
            //    return false;
            //}

            //if (Strength <= 1 || Strength >= 100)
            //{
            //    error = "Strength must be between 1 and 100.";
            //    return false;
            //}

            //if (Intelligence <= 1 || Strength >= 100)
            //{
            //    error = "Intelligence must be between 1 and 100.";
            //    return false;
            //}

            //if (Wisdom <= 1 || Strength >= 100)
            //{
            //    error = "Wisdom must be between 1 and 100.";
            //    return false;
            //}

            //if (Dexterity <= 1 || Strength >= 100)
            //{
            //    error = "Dexterity must be between 1 and 100.";
            //    return false;
            //}

            //if (Constitution <= 1 || Strength >= 100)
            //{
            //    error = "Constitution must be between 1 and 100.";
            //    return false;
            //}

            //if (IsNullOrEmpty(Profession))
            //{
            //    error = "Profession is required.";
            //    return false;
            //}

            error = null;
            return true;
        }
    }
}
