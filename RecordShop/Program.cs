
using Microsoft.EntityFrameworkCore;
using RecordShop.Model;
using RecordShop.Service;
using Microsoft.EntityFrameworkCore.InMemory;

namespace RecordShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<RecordShopDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));
            }
            else if (builder.Environment.IsProduction())
            {
                builder.Services.AddDbContext<RecordShopDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RecordShopDbContext>();
                SeedDatabase.DatabaseSeeding(context);
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
