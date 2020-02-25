using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Business
{
    public class Race
    {
        public Race ( string description )
        {
            Description = description ?? "";
        }

        public string Description { get; }

        public override string ToString ()
        {
            return Description;
        }
    }

    public class Races
    {
        public static Race[] GetAll ()
        {
            var items = new Race[5];
            items[0] = new Race("Tabaxi");
            items[1] = new Race("Elv");
            items[2] = new Race("Knome");
            items[3] = new Race("DragonBorn");
            items[4] = new Race("Tiefling");

            return items;
        }
    }
}
