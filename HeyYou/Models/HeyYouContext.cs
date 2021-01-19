using Microsoft.EntityFrameworkCore;

namespace HeyYou.Models
{
    public class HeyYouContext : DbContext
    {
        public HeyYouContext(DbContextOptions<HeyYouContext> options)
            : base(options)
        {
        }

        // public DbSet<Animal> Animals { get; set; }
    }
}