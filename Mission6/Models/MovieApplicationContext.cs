using Microsoft.EntityFrameworkCore;
namespace Mission6_Diaz.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {

        }

        public DbSet<Application> Movies { get; set; }
    }
}
