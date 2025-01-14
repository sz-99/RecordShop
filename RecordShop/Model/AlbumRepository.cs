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

        public Album PostAlbum(Album album)
        {
            RecordShopDbContext.Albums.Add(album);
            RecordShopDbContext.SaveChanges();

            return album;
        }

        public Album PutAlbum(Album album)
        {
            Album? albumToUpdate = RecordShopDbContext.Albums.FirstOrDefault(a => a.Id == album.Id);
            if (albumToUpdate == null) return null;

            albumToUpdate.Name = album.Name;
            albumToUpdate.Artist = album.Artist;
            albumToUpdate.ReleaseYear = album.ReleaseYear;
            albumToUpdate.Genre = album.Genre;
            RecordShopDbContext.SaveChanges();

            return albumToUpdate;
        }
    }

    public interface IAlbumRepository
    {
        Album GetAlbumById(int id);
        List<Album> GetAllAlbums();
        Album PostAlbum(Album album);
        Album PutAlbum(Album album);
    }
}
