
using System.Threading.Tasks;
using CustomerReviewModule.Core.Models.Search;

namespace CustomerReviewModule.Core.Services
{
    public interface ICustomerReviewSearchService
    {
        Task<CustomerReviewSearchResult> SearchCustomerReviewsAsync(CustomerReviewSearchCriteria criteria);
    }
}
