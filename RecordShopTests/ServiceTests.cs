using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Controllers;
using RecordShop.Model;
using RecordShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShopTests
{
    internal class ServiceTests
    {
        private Mock<IAlbumRepository> _albumRepositoryMock;
        private AlbumService _albumService;
        [SetUp]
        public void Setup()
        {
            _albumRepositoryMock = new Mock<IAlbumRepository>();
            _albumService = new AlbumService(_albumRepositoryMock.Object);
        }

        [Test]
        public void GetAllAbums_ReturnListOfAlbums()
        {
            //arrange
            _albumRepositoryMock.Setup(r => r.GetAllAlbums()).Returns(new List<Album>());
            List<Album> expectedList = new List<Album>();

            //act
            var result = _albumService.GetAllAlbums();

            //assert
            result.Should().BeEquivalentTo(expectedList);

        }

        [Test]
        public void GetAlbumById_ReturnsAlbum()
        {
            //arrange
            _albumRepositoryMock.Setup(r => r.GetAlbumById(1)).Returns(new Album());
            Album album= new ();

            //act
            var result = _albumService.GetAlbumById(1);

            //assert
            result.Should().BeEquivalentTo(album);

        }
    }
}
