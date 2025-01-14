using Microsoft.AspNetCore.Mvc;
using RecordShop.Model;
using RecordShop.Service;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AlbumsController : ControllerBase
    {
        private IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumService.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAlbumById(int id) 
        {
            var album = _albumService.GetAlbumById(id);
            return Ok(album);
        }

        [HttpGet]
        [Route("artist/{artist}")]
        public IActionResult GetAlbumsByArtist(string artist)
        {
            var albumsByArtists = _albumService.GetAlbumsByArtist(artist);
            if (albumsByArtists == null || albumsByArtists.Count == 0) return BadRequest("Artist does not exist.");
            return Ok(albumsByArtists);
        }

        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            var returnAlbum = _albumService.PostAlbum(album);
            return Created("/albums",album);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutAlbum(int id, Album album)
        {
            if (album == null) return BadRequest();
            var updatedAlbum = _albumService.PutAlbum(id, album);
            return Ok(updatedAlbum);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var sucess = _albumService.DeleteAlbum(id);
            if (sucess) return Ok();
            return BadRequest();
        }
    }
}
