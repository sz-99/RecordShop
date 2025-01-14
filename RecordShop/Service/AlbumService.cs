using RecordShop.Model;

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

        public Album PostAlbum(Album album)
        {
            return _albumRepository.PostAlbum(album);
        }

        public Album PutAlbum(Album album)
        {
            return _albumRepository.PutAlbum(album);
        }
    }

    public interface IAlbumService
    {
        Album GetAlbumById(int id);
        List<Album> GetAllAlbums();
        Album PostAlbum(Album album);
        Album PutAlbum(Album album);
    }
}
