using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie</summary>
    /// <remarks>
    /// lots of info
    /// </remarks>

    public class Movie
    {
        public Genre Genre { get; set; }

        /// <summary>Gets or sets the title/// </summary>
        public string Title                  // Property
        {
            get {
                // long long way
                //if(_title== null)
                //  return " ";
                // return _title;

                // long way
                //return (_title != null) ? _title : "";

                // correct way
                return _title?? "";

            }

            set { _title = value?.Trim(); }  // insure titles dont have spaces on each end
        }

        private string _title;               // field

        /// <summary>Run length in movie. </summary>
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;
        public int RunLength { get; set; }

        /// <summary>Gets or sets the description/// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        private string _description;

        /// <summary>Gets or sets the release year/// </summary>
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        public int ReleaseYear { get; set; } = 1900;                      

        /// <summary>Gets or sets the title/// </summary>
        //public bool IsClassic
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}
        //private bool _isClassic;
        public bool IsClassic { get; set; }

        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1930; }
        }

        //public int Id
        //{
        //    get { return _id; }
        //    private set { _id = value; }
        //}
        //private int _id;                      // fake test code
        public int Id { get; }

        public bool Validate (out string error)
        {
            // title is required
            if (String.IsNullOrEmpty(Title))
            {
                error = "Title is required.";
                return false;
            }

            // run Length >=0
            if (RunLength < 0)
            {
                error= "Run length must be >= 0.";
                return false;
            }

            // release year >= 900
            if (ReleaseYear < 1900)
            {
                error= "Release year must be >= 1900.";
                return false;
            }

            error = null;
            return true;
        }
    }
}
