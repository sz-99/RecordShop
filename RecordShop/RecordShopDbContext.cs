using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using RecordShop.Model;

namespace RecordShop
{
    public class RecordShopDbContext : DbContext
    {
        public RecordShopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Album> Albums { get; set; }


    }
}
