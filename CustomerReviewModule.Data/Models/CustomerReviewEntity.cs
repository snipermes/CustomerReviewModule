using System;
using System.ComponentModel.DataAnnotations;
using CustomerReviewModule.Core.Models;
using VirtoCommerce.Platform.Core.Common;

namespace CustomerReviewModule.Data.Models
{
    public class CustomerReviewEntity : AuditableEntity
    {
        [StringLength(256)]
        public string CustomerName{ get; set; }

        [Required]
        [StringLength(1024)]
        public string ReviewContent { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductId { get; set; }
        public virtual CustomerReview ToModel(CustomerReview customerReview)
        {
            if (customerReview == null)
                throw new ArgumentNullException(nameof(customerReview));

            customerReview.Id = Id;
            customerReview.CreatedBy = CreatedBy;
            customerReview.CreatedDate = CreatedDate;
            customerReview.ModifiedBy = ModifiedBy;
            customerReview.ModifiedDate = ModifiedDate;

            customerReview.CustomerName = CustomerName;
            customerReview.ReviewContent = ReviewContent;
            customerReview.IsActive = IsActive;
            customerReview.ProductId = ProductId;

            return customerReview;
        }

        public virtual CustomerReviewEntity FromModel(CustomerReview customerReview, PrimaryKeyResolvingMap pkMap)
        {
            if (customerReview == null)
                throw new ArgumentNullException(nameof(customerReview));

            pkMap.AddPair(customerReview, this);

            Id = customerReview.Id;
            CreatedBy = customerReview.CreatedBy;
            CreatedDate = customerReview.CreatedDate;
            ModifiedBy = customerReview.ModifiedBy;
            ModifiedDate = customerReview.ModifiedDate;

            CustomerName = customerReview.CustomerName;
            ReviewContent = customerReview.ReviewContent;
            IsActive = customerReview.IsActive;
            ProductId = customerReview.ProductId;

            return this;
        }

        public virtual void Patch(CustomerReviewEntity target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            target.CustomerName = CustomerName;
            target.ReviewContent = ReviewContent;
            target.IsActive = IsActive;
            target.ProductId = ProductId;
        }
    }
}
