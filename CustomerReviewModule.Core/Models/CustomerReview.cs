using VirtoCommerce.Platform.Core.Common;

namespace CustomerReviewModule.Core.Models
{
    public class CustomerReview : AuditableEntity
    {
        public string CustomerName { get; set; }
        public string ReviewContent { get; set; }
        public bool IsActive { get; set; }
        public string ProductId { get; set; }
    }
}
