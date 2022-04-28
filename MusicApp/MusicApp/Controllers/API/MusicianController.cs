using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using MusicApp.Models.Artists;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class MusiciansController : ControllerBase
    {
        private readonly ArtistService musicianService;

        public MusiciansController(ArtistService musicianService)
        {
            this.musicianService = musicianService;
        }

        [HttpGet]
        public ActionResult<List<ArtistToRead>> Get()
        {
            List<ArtistToRead> musicians = new List<ArtistToRead>();

            foreach (var musicianFromDB in musicianService.GetList())
            {
                ArtistToRead musician = new ArtistToRead
                {
                    Id = musicianFromDB.Id,
                    Description = musicianFromDB.Description,
                    Name = musicianFromDB.Name
                };

                musicians.Add(musician);
            }
            return musicians;
        }


        [HttpGet("{id}")]
        public ActionResult<ArtistToRead> Get(int id)
        {
            var musicianFromDB = musicianService.Get(id);
            ArtistToRead musician = new ArtistToRead
            {
                Id = musicianFromDB.Id,
                Description = musicianFromDB.Description,
                Name = musicianFromDB.Name
            };
            return musician;
        }


        [HttpPost]
        public ActionResult<ArtistToSave> Post(ArtistToSave musician)
        {
            Artist musicianFromDB = new Artist
            {
                Id = 0,
                Description = musician.Description,
                Name = musician.Name
            };
            musicianService.Create(musicianFromDB);
            return Ok(musician);
        }


        [HttpPut]
        public ActionResult Put(ArtistToSave musician)
        {
            Artist musicianFromDB = new Artist
            {
                Id = musician.Id,
                Description = musician.Description,
                Name = musician.Name
            };

            musicianService.Update(musicianFromDB);
            return Ok(musician);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var musician = musicianService.Get(id);
            if (musician == null)
            {
                return BadRequest();
            }

            musicianService.Delete(id);
            return Ok("Artist removed succesfully");
        }
    }
}
