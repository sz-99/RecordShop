using Microsoft.AspNetCore.Mvc;
using RecordShop.Service;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AlbumsController : Controller
    {
        private IAlbumService _albumService;
        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            return Ok();
        }
    }
}
