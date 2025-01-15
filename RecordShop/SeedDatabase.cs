using Microsoft.Identity.Client;
using RecordShop.Model;

namespace RecordShop
{
    public class SeedDatabase
    {

        public static void DatabaseSeeding (RecordShopDbContext context)
        {
            if(!context.Albums.Any())
            {
                context.Albums.AddRange(
                    new Model.Album() { Id = 1, Name = "30", Artist = "Adele", ReleaseYear = 2021, Genre = Genre.Pop },
                    new Model.Album() { Id = 2, Name = "21", Artist = "Adele", ReleaseYear = 2011, Genre = Genre.Pop },
                    new Model.Album() { Id = 3, Name = "Hotel California", Artist = "Eagles", ReleaseYear = 1976, Genre = Genre.Country }
                    );
                context.SaveChanges();
            }
        }
    }
}
