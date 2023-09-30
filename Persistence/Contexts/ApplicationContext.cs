using Application.Enums;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.ApplyConfiguration(new UserConfiguration());
            // builder.ApplyConfiguration(new PostConfiguration());
            // builder.ApplyConfiguration(new CommentConfiguration());

            #region PropertyFeatures
            builder.Entity<PropertyFeatures>().Property(r => r.HasAirConditioning).HasDefaultValue(false);
            builder.Entity<PropertyFeatures>().Property(r => r.HasBalcony).HasDefaultValue(false);
            builder.Entity<PropertyFeatures>().Property(r => r.HasBarbecueGrill).HasDefaultValue(false);
            builder.Entity<PropertyFeatures>().Property(r => r.HasGarden).HasDefaultValue(false);
            builder.Entity<PropertyFeatures>().Property(r => r.HasGym).HasDefaultValue(false);
            builder.Entity<PropertyFeatures>().Property(r => r.HasPool).HasDefaultValue(false);
            #endregion
            
            #region Property
            builder.Entity<Property>().Property(r => r.Title).HasMaxLength(50);
            builder.Entity<Property>().Property(r => r.Description).HasMaxLength(50);
            builder.Entity<Property>().Property(r => r.Address).HasMaxLength(50);
            builder.Entity<Property>().Property(r => r.Latitude).HasMaxLength(15);
            builder.Entity<Property>().Property(r => r.Longitude).HasMaxLength(15);

            builder.Entity<Property>().HasOne(p => p.PropertyType)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.PropertyTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Property>().HasMany(p => p.Transactions)
                .WithOne( p => p.Property)
                .HasForeignKey(p => p.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Property>().HasMany(p => p.Photos)
                .WithOne(p => p.Property)
                .HasForeignKey(p => p.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Property>().HasMany(p => p.Comments)
                .WithOne(p => p.Property)
                .HasForeignKey(p => p.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Property>().HasMany(p => p.Reviews)
                .WithOne(p => p.Property)
                .HasForeignKey(p => p.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Property>().HasOne(p => p.PropertyFeatures)
                .WithOne(p => p.Property)
                .HasForeignKey<PropertyFeatures>(p => p.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            //Indexes
            builder.Entity<Property>().HasIndex(p => p.UserId);
            
            #endregion

            #region Comment
            builder.Entity<Comment>().Property(r => r.Content).HasMaxLength(150);

            //Indexes
            builder.Entity<Comment>().HasIndex(p => p.UserId);
            #endregion

            #region Review
            builder.Entity<Review>().Property(r => r.Content).HasMaxLength(150);
            builder.Entity<Review>().Property(r => r.Rating).IsRequired();

            //Indexes
            builder.Entity<Review>().HasIndex(p => p.UserId);
            builder.Entity<Review>().HasCheckConstraint("CK_Rating", "Rating >= 1 AND Rating <= 5");
            #endregion

            #region PropertyType
            builder.Entity<PropertyType>().Property(r => r.Name).HasMaxLength(25);

            builder.Entity<PropertyType>().HasData(
                new { Id = (int)PropertyTypeEnum.Land, Name = nameof(PropertyTypeEnum.Land) },
                new { Id = (int)PropertyTypeEnum.House, Name = nameof(PropertyTypeEnum.House) },
                new { Id = (int)PropertyTypeEnum.Apartment, Name = nameof(PropertyTypeEnum.Apartment) }
            );
            #endregion

            #region Transaction
            builder.Entity<Transaction>().Property(r => r.Description).HasMaxLength(50);
            
            //Indexes
            builder.Entity<Transaction>().HasIndex(p => p.UserId);
            #endregion

            #region FavoriteProperty
            //Indexes
            builder.Entity<FavoriteProperty>().HasIndex(p => p.UserId);
            #endregion

            #region TransactionType
            builder.Entity<TransactionType>().Property(r => r.Name).HasMaxLength(25);

            builder.Entity<TransactionType>().HasMany(p => p.Transactions)
                .WithOne(p => p.TransactionType)
                .HasForeignKey(p => p.TransactionTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            //seeding
            builder.Entity<TransactionType>().HasData(
                new { Id = (int)TransactionTypeEnum.Rent, Name = nameof(TransactionTypeEnum.Rent) },
                new { Id = (int)TransactionTypeEnum.Sale, Name = nameof(TransactionTypeEnum.Sale) }
            );
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
