using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoesArcade.Models
{
    public class VideoGame
    {
        //The VideoGame Table Columns
        public int VideoGameID { get; set; }
        public int Year { get; set; }
        public string Game { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string OriginalPlatform { get; set; }
    }
}
