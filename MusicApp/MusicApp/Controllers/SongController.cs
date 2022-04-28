using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApp.Models;
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
        public static List<Song> Songs;
        private readonly SongService songService;

        public SongController(SongService songService)
        {
            this.songService = songService;
        }

        [HttpGet]
        public ActionResult<List<Song>> Get()
        {
            return songService.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            return songService.Get(id);
        }

        [HttpPost]
        public ActionResult<Song> Post(Song song)
        {
            song.Id = 0;
            songService.Create(song);
            return Ok(song);
        }

        [HttpPut]
        public ActionResult Put(Song song)
        {
            songService.Update(song);
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
