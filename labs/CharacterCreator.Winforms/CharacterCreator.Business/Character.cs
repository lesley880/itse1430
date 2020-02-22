using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Business
{
    public class Character
    {
        public string Name                       // Property
        {
            get { return _name??""; }            // name doesnt have space at end
            set { _name = value?.Trim(); }
        }
        private string _name;                    // field

        //public string Profession
        //{

        //}

        //public string Race
        //{

        //}
        //public string Attributes
        //{

        //}

        public string Desciption
        {
            get { return _description??""; }     
            set { _description = value?.Trim(); }
        }
        private string _description;
    }
}
