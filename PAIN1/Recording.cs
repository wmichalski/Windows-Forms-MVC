using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN1
{
    public class Recording
    {
        public string Name
        {
            get;
            set;
        }

        public string Artist
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public string Genre
        {
            get;
            set;
        }


        public Recording(string name, string artist, DateTime releaseDate, string genre)
        {
            Name = name;
            Artist = artist;
            ReleaseDate = releaseDate;
            Genre = genre;
        }
    }
}
