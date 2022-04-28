using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private static List<Song> Songs;
        private readonly ILogger<SongController> _logger;

        public SongController(ILogger<SongController> logger)
        {
            _logger = logger;

            Songs = new List<Song>()
            {
                new Song {Id = 1, Name = "Let me be your woman", Author = "Doja Cat",
                    Address = "https://api.meowpad.me/v2/sounds/preview/59561.m4a"},
                new Song {Id = 2, Name = "Jewish drip", Author = "Jews",
                    Address = "https://api.meowpad.me/v2/sounds/preview/26407.m4a"}
            };
        }

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return Songs;
        }

        [HttpGet("{id}")]
        public Song Get(int id)
        {
            Song song = new Song();
            foreach(Song s in Songs)
            {
                if (s.Id == id)
                    song = s;
            }

            return song;
        }
    }
}
