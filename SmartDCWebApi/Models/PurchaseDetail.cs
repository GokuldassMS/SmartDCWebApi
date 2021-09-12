using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class PurchaseDetail
    {
        public PurchaseDetail()
        {
            DeliveryDetails = new HashSet<DeliveryDetail>();
            PurchaseDetailParticulars = new HashSet<PurchaseDetailParticular>();
        }

        public int PurchaseId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string StyleNo { get; set; }
        public string DcNo { get; set; }
        public string VehicleNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Company Company { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }
        public virtual ICollection<PurchaseDetailParticular> PurchaseDetailParticulars { get; set; }
    }
}
