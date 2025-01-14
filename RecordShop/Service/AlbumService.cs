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
    }

    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
    }
}
