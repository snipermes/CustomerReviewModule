using System.Linq;
using System.Threading.Tasks;
using CustomerReviewModule.Data.Models;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace CustomerReviewModule.Data.Repositories
{
    public class CustomerReviewRepository : DbContextRepositoryBase<CustomerReviewModuleDbContext>, ICustomerReviewRepository
    {

        public CustomerReviewRepository(CustomerReviewModuleDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<CustomerReviewEntity> CustomerReviews => DbContext.Set<CustomerReviewEntity>();

        public async Task<CustomerReviewEntity[]> GetByIdsAsync(string[] ids)
        {
            return await CustomerReviews.Where(x => ids.Contains(x.Id)).ToArrayAsync();
        }
    }

}
