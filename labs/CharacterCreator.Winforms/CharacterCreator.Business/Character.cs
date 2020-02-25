using System;
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

        public string Attributes { get; set; }

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

            //if (IsNullOrEmpty(Profession))
            //{
            //    error = "Profession is required.";
            //    return false;
            //}

            //if (String.IsNullOrEmpty(Race))
            //{
            //    error= "Race is required.";
            //    return false;
            //}

            if (String.IsNullOrEmpty(Attributes))
            {
                error = "Attribute is required.";
                return false;
            }

            error = null;
            return true;
        }
    }
}
