﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Business
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate (object value)
        {
            var errors = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);
            return errors;
        }
    }
}
