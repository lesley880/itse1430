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
        /// <summary>Gets or sets the title/// </summary>
        public string Title                  // Property
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _title;               // field

        /// <summary>Run length in movie. </summary>
        public int RunLength
        {
            get { return _runLength; }
            set { _runLength = value; }
        }

        private int _runLength;

        /// <summary>Gets or sets the description/// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _description;

        /// <summary>Gets or sets the release year/// </summary>
        public int ReleaseYear
        {
            get { return _releaseYear }
            set { _releaseYear = value; }
        }
        private int _releaseYear;

        /// <summary>Gets or sets the title/// </summary>
        public bool InClassic
        {

        }
}
