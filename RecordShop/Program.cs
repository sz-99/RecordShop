
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RecordShop.Model;
using RecordShop.Service;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            builder.Services.AddHealthChecks()
                                    .AddCheck("App Running", () => HealthCheckResult.Healthy("The application is running.")).AddDbContextCheck<RecordShopDbContext>("Database");

            builder.Services
              .AddAuthentication(options => {
                  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(
              options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = false,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = "northcoders",
                      ValidAudience = "northcoders",
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ExtremelySuperLongSecretKeyForRecordShopAuthentication")),
                      RoleClaimType = "roles"
                  };
                  options.MapInboundClaims = false;
              });

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

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapHealthChecks("/health");


            app.MapControllers();

            app.Run();
        }
    }
}
