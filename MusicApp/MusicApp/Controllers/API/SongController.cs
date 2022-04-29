using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApp.Models;
using MusicApp.Models.Songs;
using MusicApp.Services;
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
        private readonly SongService songService;

        public SongController(SongService songService)
        {
            this.songService = songService;
        }

        [HttpGet]
        public ActionResult<List<SongToRead>> Get()
        {
            List<SongToRead> songs = new List<SongToRead>();
            foreach (var songFromDB in songService.GetList())
            {
                SongToRead song = new SongToRead
                {
                    Id = songFromDB.Id,
                    Address = songFromDB.Address,
                    ArtistId = songFromDB.ArtistId,
                    Artist = new ArtistToSave
                    {
                        Id = songFromDB.Artist.Id,
                        Description = songFromDB.Artist.Description,
                        Name = songFromDB.Artist.Name
                    },
                    Name = songFromDB.Name
                };

                songs.Add(song);
            }
            return songs;
        }

        [HttpGet("{id}")]
        public ActionResult<SongToRead> Get(int id)
        {
            var songFromDB = songService.Get(id);
            SongToRead song = new SongToRead
            {
                Id = songFromDB.Id,
                Address = songFromDB.Address,
                ArtistId = songFromDB.ArtistId,
                Artist = new ArtistToSave
                {
                    Id = songFromDB.Artist.Id,
                    Description = songFromDB.Artist.Description,
                    Name = songFromDB.Artist.Name
                },
                Name = songFromDB.Name
            };
            return song;
        }

        [HttpPost]
        public ActionResult<SongToSave> Post(SongToSave song)
        {
            Song songFromDB = new Song
            {
                Id = 0,
                Address = song.Address,
                ArtistId = song.ArtistId,
                Name = song.Name
            };
            songService.Create(songFromDB);
            return Ok(song);
        }

        [HttpPut]
        public ActionResult Put(SongToSave song)
        {
            Song songFromDB = new Song
            {
                Id = song.Id,
                Address = song.Address,
                ArtistId = song.ArtistId,
                Name = song.Name
            };

            songService.Update(songFromDB);
            return Ok(song);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var song = songService.Get(id);
            if (song == null)
            {
                return BadRequest();
            }

            songService.Delete(id);
            return Ok("Song removed succesfully");
        }
    }
}
