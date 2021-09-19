using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class DeliveryDetails
    {
        public DeliveryDetails()
        {
            DeliveryDetailParticulars = new HashSet<DeliveryDetailParticular>();
        }

        public int DeliveryId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int PurchaseId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string PartyDcNo { get; set; }
        public string ChallanNo { get; set; }
        public string VehicleNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PurchaseDetail Purchase { get; set; }
        public virtual ICollection<DeliveryDetailParticular> DeliveryDetailParticulars { get; set; }
    }

    public partial class DeliveryDetail
    {
        public DeliveryDetail()
        {
            DeliveryDetailParticulars = new HashSet<DeliveryDetailParticular>();
        }

        public int DeliveryId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int PurchaseId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string PartyDcNo { get; set; }
        public string ChallanNo { get; set; }
        public string VehicleNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual Company Company { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PurchaseDetail Purchase { get; set; }
        public virtual ICollection<DeliveryDetailParticular> DeliveryDetailParticulars { get; set; }
    }
}
