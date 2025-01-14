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

        public List<Album> GetAlbumsByArtist(string artist)
        {
            bool artistExists = RecordShopDbContext.Albums.Any(a => a.Artist.ToLower() == artist.ToLower());
            if (!artistExists) return null;
            var albumsByArtist = RecordShopDbContext.Albums
                                                        .Where(a=>a.Artist.ToLower() == artist.ToLower())
                                                        .ToList();
            return albumsByArtist;
        }

        public List<Album> GetAlbumsByYear(int year)
        {
            bool yearExists = RecordShopDbContext.Albums.Any(a => a.ReleaseYear == year);
            if (!yearExists) return null;
            var albumsByYear = RecordShopDbContext.Albums
                                                    .Where(a => a.ReleaseYear == year)
                                                    .ToList();
            return albumsByYear;
        }

        public Album GetAlbumByName(string name)
        {
            bool albumExists = RecordShopDbContext.Albums.Any(a => a.Name == name);
            if (!albumExists) return null;
            Album albumToReturn = RecordShopDbContext.Albums.FirstOrDefault(a => a.Name == name);

            return albumToReturn;
        }

        public Album PostAlbum(Album album)
        {
            RecordShopDbContext.Albums.Add(album);
            RecordShopDbContext.SaveChanges();

            return album;
        }

        public Album PutAlbum(int id, Album album)
        {
            Album? albumToUpdate = RecordShopDbContext.Albums.FirstOrDefault(a => a.Id == id);
            if (albumToUpdate == null) return null;

            albumToUpdate.Name = album.Name;
            albumToUpdate.Artist = album.Artist;
            albumToUpdate.ReleaseYear = album.ReleaseYear;
            albumToUpdate.Genre = album.Genre;
            RecordShopDbContext.SaveChanges();

            return albumToUpdate;
        }

        public bool DeleteAlbum(int id)
        {
            Album? albumToDelete = RecordShopDbContext.Albums.FirstOrDefault(a => a.Id == id);
            if (albumToDelete == null) return false;

            RecordShopDbContext.Albums.Remove(albumToDelete);
            RecordShopDbContext.SaveChanges();
            return true;
        }

        
    }

    public interface IAlbumRepository
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
