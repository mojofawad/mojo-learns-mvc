using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using MojoMVC.Models.Entities;

namespace MojoMVC.Infrastructure
{
    public class MojoDbContext : DbContext
    {
        public MojoDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<DbFeed> Feeds { get; set; }
        public DbSet<DbFeedItem> FeedItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbFeed>()
                .Property(t => t.Link)
                .HasColumnAnnotation("Index", new  IndexAnnotation(new IndexAttribute { IsUnique = true }))
                .HasMaxLength(450);
        }
    }
}