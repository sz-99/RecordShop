
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

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            //else if(app.Environment.IsProduction())
            //{
            //    builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseSqlServer(connectionString));
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
