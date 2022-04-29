using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models.Songs
{
    public class SongToRead
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public ArtistToSave Artist { get; set; }

        public string Address { get; set; }
    }
}
