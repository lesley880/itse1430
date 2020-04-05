using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Lesley Reller
 * ITSE 1430
 * 04/01/2020
 */

namespace CharacterCreator.Business
{
    public class MemoryCharacterDatabase : CharacterDatabase
    {
        protected override Character AddCore ( Character character )
        {
            var item = CloneCharacter(character);
            item.Id = _id++;
            _characters.Add(item);

            return CloneCharacter(item);
        }

        protected override void DeleteCore ( int id )
        {
            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);
        }

        protected override Character GetCore ( int id )
        {
            var character = FindById(id);
            if (character == null)
                return null;

            return CloneCharacter(character);
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            var items = _characters.Where(c => true);

            return _characters.Select(c => CloneCharacter(c));
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var exsisting = FindById(id);
            // Update
            CopyCharacter(exsisting, character, false);
        }

        private Character CloneCharacter ( Character character )
        {
            var item = new Character();
            CopyCharacter(item, character, true);

            return item;
        }

        private void CopyCharacter ( Character target, Character source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;

            if (source.Profession != null)
                target.Profession = new Profession(source.Profession.Description);
            else
                target.Profession = null;

            if (source.Race != null)
                target.Race = new Race(source.Race.Description);
            else
                target.Race = null;

            target.Strength = source.Strength;
            target.Intelligence = source.Intelligence;
            target.Wisdom = source.Wisdom;
            target.Dexterity = source.Dexterity;
            target.Constitution = source.Constitution;
        }

        protected override Character FindByName ( string name ) => _characters.FirstOrDefault(c => String.Compare(c?.Name, name, true) == 0); // Extention method

        protected override Character FindById ( int id ) => _characters.FirstOrDefault(c => c.Id == id);

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;
    }
}