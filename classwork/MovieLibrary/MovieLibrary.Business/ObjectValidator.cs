using System.Collections.Generic;

namespace MovieLibrary.Business
{
    //public interface ISelectableObject
    //{
    //    void Select ();
    //}

    //public interface IResizableObject
    //{
    //    void Resize ( int width, int height );
    //}

    //public struct SelectableResizableObject : IResizableObject, ISelectableObject
    //{
    //    public void Resize ( int width, int height );
    //    public void Select ();
    //}
    namespace MovieLibrary.Business
    {
        public class ObjectValidator
        {
            public IEnumerable<ValidationResult> Validate ( object value )
            {
                var errors = new List<ValidationResult>();

                Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

                return errors;
            }
        }
    }
}

