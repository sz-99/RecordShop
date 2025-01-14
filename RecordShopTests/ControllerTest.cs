using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Controllers;
using RecordShop.Model;
using RecordShop.Service;

namespace RecordShopTests
{
    public class ControllerTests
    {
        private Mock<IAlbumService> _albumServiceMock;
        private AlbumsController _albumsController;
        [SetUp]
        public void Setup()
        {
            _albumServiceMock = new Mock<IAlbumService>();
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

        [Test]
        public void GetAlbumById_ReturnsOkAndAlbum()
        {
            //arrange 
            _albumServiceMock.Setup(s => s.GetAlbumById(1)).Returns(new Album());
            Album albumToReturn = new();

            //act
            var result = _albumsController.GetAlbumById(1);

            //assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(albumToReturn);


        }

        [Test]
        public void PostAlbum_ReturnCreated()
        {
            //act
            var result = _albumsController.PostAlbum(new Album());

            //assert
            result.Should().BeOfType<CreatedResult>();

        }

        [Test]
        public void PutAlbum_nullReturnBadRequest()
        {
            //arrange 
            Album album = new Album();
            Album nullAlbum = null;
            _albumServiceMock.Setup(s => s.PutAlbum(album)).Returns(nullAlbum);

            //act
            var result = _albumsController.PutAlbum(nullAlbum);

            //assert
            result.Should().BeOfType<BadRequestResult>();

        }
    }
}