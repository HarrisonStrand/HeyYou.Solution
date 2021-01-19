using Microsoft.EntityFrameworkCore;

namespace HeyYou.Models
{
    public class HeyYouContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMessage> GroupMessage { get; set; }
        public HeyYouContext(DbContextOptions<HeyYouContext> options)
            : base(options)
        {
        }
    }
}