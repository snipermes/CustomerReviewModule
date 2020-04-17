using System.Threading.Tasks;
using CustomerReviewModule.Core;
using CustomerReviewModule.Core.Models;
using CustomerReviewModule.Core.Models.Search;
using CustomerReviewModule.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CustomerReviewModule.Web.Controllers.Api
{
    [Route("api")]
    public class CustomerReviewModuleController : Controller
    {
        private readonly ICustomerReviewSearchService _customerReviewSearchService;
        private readonly ICustomerReviewService _customerReviewService;



        public CustomerReviewModuleController(ICustomerReviewSearchService customerReviewSearchService, ICustomerReviewService customerReviewService)
        {
            _customerReviewSearchService = customerReviewSearchService;
            _customerReviewService = customerReviewService;
        }
        /// <summary>
        /// Return product Customer review search results
        /// </summary>
        [HttpPost]
        [Route("search")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public async Task<ActionResult<CustomerReviewSearchResult>> SearchCustomerReviews([FromBody]CustomerReviewSearchCriteria criteria)
        {
            var result = await _customerReviewSearchService.SearchCustomerReviewsAsync(criteria);
            return result;
        }

        /// <summary>
        ///  Create new or update existing customer review
        /// </summary>
        /// <param name="customerReviews">Customer reviews</param>
        /// <returns></returns>
        [HttpPost]
        [Route("reviews")]
        [Authorize(ModuleConstants.Security.Permissions.Update)]
        public async Task<ActionResult> Update([FromBody]CustomerReview[] customerReviews)
        {
            await _customerReviewService.SaveCustomerReviewsAsync(customerReviews);
            return NoContent();
        }

        /// <summary>
        /// Delete Customer Reviews by IDs
        /// </summary>
        /// <param name="ids">IDs</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("reviews")]
        [Authorize(ModuleConstants.Security.Permissions.Delete)]
        public async Task<ActionResult> Delete([FromQuery] string[] ids)
        {
            await _customerReviewService.DeleteCustomerReviewsAsync(ids);
            return NoContent();
        }
    }
}
