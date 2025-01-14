namespace RecordShop.Model
{
    public class AlbumRepository :IAlbumRepository
    {
        private RecordShopDbContext RecordShopDbContext { get; set; }
        public AlbumRepository(RecordShopDbContext recordShopDbContext)
        {
            RecordShopDbContext = recordShopDbContext;
        }
        public List<Album> GetAllAlbums()
        {
            return RecordShopDbContext.Albums.ToList();
        }

        public Album GetAlbumById(int id)
        {
            var album = RecordShopDbContext.Albums.FirstOrDefault(a => a.Id == id);
            return album;
        }
    }

    public interface IAlbumRepository
    {
        Album GetAlbumById(int id);
        List<Album> GetAllAlbums();
    }
}
