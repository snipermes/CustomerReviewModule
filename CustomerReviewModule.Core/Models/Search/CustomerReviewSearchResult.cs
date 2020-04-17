using VirtoCommerce.Platform.Core.Common;

namespace CustomerReviewModule.Core.Models.Search
{
    public class CustomerReviewSearchResult : GenericSearchResult<CustomerReview>
    {
        public string[] ProductIds { get; set; }
        public bool? IsActive { get; set; }
    }
}
