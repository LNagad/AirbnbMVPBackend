using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FavoriteProperty> FavoriteProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyFeatures> PropertyFeatures { get; set; }   
        public DbSet<PropertyPhotos> PropertyPhotos { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    // builder.ApplyConfiguration(new UserConfiguration());
        //    // builder.ApplyConfiguration(new PostConfiguration());
        //    // builder.ApplyConfiguration(new CommentConfiguration());
        //}
    }
}
