using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidate ( object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }

        public static void Validate ( object value )
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);
        }
    }
}