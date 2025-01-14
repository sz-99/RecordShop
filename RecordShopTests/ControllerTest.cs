using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Controllers;
using RecordShop.Service;

namespace RecordShopTests
{
    public class ControllerTests
    {
        private IAlbumService _albumService;
        private AlbumsController _albumsController;
        [SetUp]
        public void Setup()
        {
            Mock<IAlbumService> _albumServiceMock = new Mock<IAlbumService>();
            _albumsController = new AlbumsController( _albumServiceMock.Object );

        }

        [Test]
        public void GetAllAbums_ReturnOk()
        {
            //act
            var result = _albumsController.GetAllAlbums();

            //assert
            result.Should().BeOfType<OkObjectResult>();
        
        }
    }
}