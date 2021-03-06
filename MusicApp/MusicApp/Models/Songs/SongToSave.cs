using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class SongToSave
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public string Address { get; set; }
    }
}
