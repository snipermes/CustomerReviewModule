using CustomerReviewModule.Data.Models;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;


namespace CustomerReviewModule.Data.Repositories
{
    public class CustomerReviewModuleDbContext : DbContextWithTriggers
    {
        public CustomerReviewModuleDbContext(DbContextOptions<CustomerReviewModuleDbContext> options)
          : base(options)
        {

        }

        protected CustomerReviewModuleDbContext(DbContextOptions options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region CustomerReviewEntity
            modelBuilder.Entity<CustomerReviewEntity>().ToTable("CustomerReview").HasKey(x => x.Id);
            modelBuilder.Entity<CustomerReviewEntity>().Property(x => x.Id).HasMaxLength(128);
            base.OnModelCreating(modelBuilder);
            #endregion

        }
    }
}

