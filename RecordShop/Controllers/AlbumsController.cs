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
    }
}
