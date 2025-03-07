﻿using RecordShop.Model;

namespace RecordShop.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }

        public Album GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        public List<Album> GetAlbumsByArtist(string artist)
        {
            return _albumRepository.GetAlbumsByArtist(artist);
        }

        public List<Album> GetAlbumsByYear(int year)
        {
            return _albumRepository.GetAlbumsByYear(year);
        }

        public Album GetAlbumByName(string name)
        {
            return _albumRepository.GetAlbumByName(name);
        }

        public Album PostAlbum(Album album)
        {
            return _albumRepository.PostAlbum(album);
        }

        public Album PutAlbum(int id, Album album)
        {
            return _albumRepository.PutAlbum(id, album);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumRepository.DeleteAlbum(id);
        }
    }

    public interface IAlbumService
    {
        bool DeleteAlbum(int id);
        Album GetAlbumById(int id);
        Album GetAlbumByName(string name);
        List<Album> GetAlbumsByArtist(string artist);
        List<Album> GetAlbumsByYear(int year);
        List<Album> GetAllAlbums();
        Album PostAlbum(Album album);
        Album PutAlbum(int id, Album album);
    }
}
