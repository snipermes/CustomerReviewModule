
using System.Linq;
using System.Threading.Tasks;
using CustomerReviewModule.Data.Models;
using VirtoCommerce.Platform.Core.Common;

namespace CustomerReviewModule.Data.Repositories
{
    public interface ICustomerReviewRepository : IRepository
    {
        IQueryable<CustomerReviewEntity> CustomerReviews { get; }

        Task<CustomerReviewEntity[]> GetByIdsAsync(string[] ids);
    }
}