using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Lesley Reller
 * ITSE 1430
 * 03/26/2020
 */

namespace CharacterCreator.Business
{
    public abstract class CharacterDatabase : ICharacterDatabase
    {
        public Character Add ( Character character )
        {
            // TODO: Validate
            if (character == null)
                return null;

            // .NET
            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                return null;

            // name is unique
            var exsisting = FindByName(character.Name);
            if (exsisting != null)
                return null;
            return AddCore(character);
        }

        protected abstract Character AddCore ( Character character );

        public void Delete ( int id )
        {
            //TODO: Validate
            if (id <=0)
                return;
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Character Get ( int id )
        {
            //TODO: error
            if (id <= 0)
                return null;
            return GetCore(id);
        }

        protected abstract Character GetCore ( int id );

        public IEnumerable<Character> GetAll () => GetAllCore() ?? Enumerable.Empty <Character>();

        protected abstract IEnumerable<Character> GetAllCore ();

        public string Update ( int id, Character character )
        {
            //TODO: Validate
            if (character == null)
                return "Character is null";

            var errors = ObjectValidator.Validate(character);

            //if (!character.Validate(out var error))
            //    return error;

            if (id <= 0)
                return "ID is invalid.";

            var exsisting = FindById(id);
            if (exsisting == null)
                return "Character not found";

            var sameName = FindByName(character.Name);
            if (sameName != null  && sameName.Id != id)
                return "Character must be unique.";

            // Update
            UpdateCore(id, character);

            return null;
        }

        protected abstract void UpdateCore ( int id, Character character );

        protected abstract Character FindByName ( string name );

        protected abstract Character FindById ( int id );

    }
}