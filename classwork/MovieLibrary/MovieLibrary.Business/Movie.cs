using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie : IValidatableObject
    {
        public int Id { get; set; }

        public Genre Genre { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            //Never return null from a string property, always return empty string
            get {
                return _title ?? "";
            }

            //Use null conditional operator if instance value can be null
            set { _title = value?.Trim(); }
        }

        /// <summary>Gets or sets the run length in minutes.</summary>        
        public int RunLength { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>        
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Determines if this is a classic movie.</summary>        
        public bool IsClassic { get; set; }

        //Calculated property, no setter
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1930; }
        }

        public override string ToString ()
        {
            return Title;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //Title is required
            //if (txtTitle.Text?.Trim() == "")
            if (String.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Title is required.", new[] { nameof(Title) }); //"Title"
                //error = "Title is required.";
            };

            //Run length >= 0
            if (RunLength < 0)
            {
                yield return new ValidationResult("Run length must be >= 0.", new[] { nameof(RunLength) }); //"RunLength"
                //error = "Run length must be >= 0.";              
            };

            //Release year >= 1900
            if (ReleaseYear < 1900)
            {
                yield return new ValidationResult("Release year must be >= 1900.", new[] { nameof(ReleaseYear) });
                //error = "Release year must be >= 1900.";                
            };

            //error = null;
            //return true;
        }

        private string _title;
        private string _description;
    }
}
