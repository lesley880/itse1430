using System.Collections.Generic;

/*
* Lesley Reller
* ITSE 1430
* 03/26/2020
*/

namespace CharacterCreator.Business
{
    public interface ICharacterDatabase
    {
        Character Add ( Character character );
        void Delete ( int id );
        Character Get ( int id );
        IEnumerable <Character> GetAll ();
        string Update ( int id, Character character );
    }
}