using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Business
{
    public class Profession
    {
        public Profession ( string description )
        {
            Description = description ?? "";
        }

        public string Description { get; }

        public override string ToString ()
        {
            return Description;
        }
    }

    public class Professions
    {
        public static Profession[] GetAll ()
        {
            var items = new Profession[5];
            items[0] = new Profession("Barbarian");
            items[1] = new Profession("Ranger");
            items[2] = new Profession("Cleric");
            items[3] = new Profession("Rogue");
            items[4] = new Profession("Druid");

            return items;
        }
    }
}
