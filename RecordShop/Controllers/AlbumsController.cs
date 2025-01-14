using Microsoft.AspNetCore.Mvc;
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
    }
}
