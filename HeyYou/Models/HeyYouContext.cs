using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                .HasData(
                    new Message
                    {
                        MessageId = 1,
                        MessageTitle = "Fight Club",
                        MessageBody = "The first rule of fight club is you don't talk about fight club",
                        MessageAuthor = "Chuck Palahniuk",
                        MessageDate = new DateTime(2020, 5, 1, 8, 30, 53)
                    },
                    new Message
                    {
                        MessageId = 2,
                        MessageTitle = "Naked Lunch",
                        MessageBody = "Drugs",
                        MessageAuthor = "William S Burroughs",
                        MessageDate = new DateTime(2020, 5, 1, 8, 30, 53)
                    },
                    new Message
                    {
                        MessageId = 3,
                        MessageTitle = "White Oleander",
                        MessageBody = "prisons and mommy issues",
                        MessageAuthor = "Janet Fitch",
                        MessageDate = new DateTime(2020, 5, 1, 8, 30, 53)
                    },
                    new Message
                    {
                        MessageId = 4,
                        MessageTitle = "oldmen",
                        MessageBody = "seas",
                        MessageAuthor = "Hemingway",
                        MessageDate = new DateTime(2020, 5, 1, 8, 30, 53)
                    },
                    new Message
                    {
                        MessageId = 5,
                        MessageTitle = "lets get dark",
                        MessageBody = "lets get weird",
                        MessageAuthor = "H.P. Lovecraft",
                        MessageDate = new DateTime(2020, 5, 1, 8, 30, 53)
                    }
                );
            builder.Entity<Group>()
            .HasData(
                new Group
                {
                    GroupId = 1,
                    GroupName = "Pawn Stars",
                    GroupDescription = "Best I can do is 600",
                },
                new Group
                {
                    GroupId = 2,
                    GroupName = "Real Housewives",
                    GroupDescription = "Life isn't all diamonds and rose, but it should be.",
                }
            );
            builder.Entity<GroupMessage>()
            .HasData(
                //Naked Lunch & RHW
                new GroupMessage
                {
                    GroupMessageId = 1,
                    MessageId = 2,
                    GroupId = 2,
                },
                //Fight Club & PawnStars
                new GroupMessage
                {
                    GroupMessageId = 2,
                    MessageId = 1,
                    GroupId = 1,
                }
            );
        }
    }
}