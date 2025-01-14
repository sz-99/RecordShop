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
    }

    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();
    }
}
