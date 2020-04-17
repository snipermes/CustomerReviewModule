
using System.Threading.Tasks;
using CustomerReviewModule.Core.Models;

namespace CustomerReviewModule.Core.Services
{
    public interface ICustomerReviewService
    {
        Task<CustomerReview[]> GetByIdsAsync(string[] ids);

        Task SaveCustomerReviewsAsync(CustomerReview[] items);

        Task DeleteCustomerReviewsAsync(string[] ids);
    }
}
