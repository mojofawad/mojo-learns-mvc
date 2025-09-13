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

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>()
                .Property(t => t.Link)
                .HasColumnAnnotation("Index", new  IndexAnnotation(new IndexAttribute { IsUnique = true }))
                .HasMaxLength(450);
        }
    }
}