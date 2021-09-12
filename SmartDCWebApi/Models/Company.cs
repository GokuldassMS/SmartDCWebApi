using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class Company
    {
        public Company()
        {
            DeliveryDetails = new HashSet<DeliveryDetail>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string GstNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhoneNoCode { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNoCode { get; set; }
        public string AltPhoneNo { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
