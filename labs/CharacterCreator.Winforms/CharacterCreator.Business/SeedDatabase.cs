using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Lesley Reller
 * ITSE 1430
 * 03/26/2020
 */

namespace CharacterCreator.Business
{
    public static class SeedDatabase
    {
        public static ICharacterDatabase SeedIfEmpty ( this ICharacterDatabase database )
        {
            if (!database.GetAll().Any())
            {
                var demo = new Character() { Name = "Lark", Strength = 50, Intelligence = 30, Wisdom = 10, Dexterity = 10, Constitution = 20 };
                var items = new[] {
                    new Character() {Name = "Lapis", Strength = 7, Intelligence = 30, Wisdom = 10, Dexterity = 10, Constitution = 20 },
                    new Character() {Name = "Evan", Strength = 5, Intelligence = 30, Wisdom = 1, Dexterity = 10, Constitution = 15 },
                    demo,
                };
                foreach (var item in items)
                    database.Add(item);
            }
            return database;
        }
    }
}
