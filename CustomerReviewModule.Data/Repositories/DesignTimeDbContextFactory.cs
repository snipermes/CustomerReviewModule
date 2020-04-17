using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CustomerReviewModule.Data.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CustomerReviewModuleDbContext>
    {
        public CustomerReviewModuleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CustomerReviewModuleDbContext>();

            builder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=virto;Password=virto;MultipleActiveResultSets=True;Connect Timeout=30");

            return new CustomerReviewModuleDbContext(builder.Options);
        }
    }
}
