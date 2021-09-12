using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class User
    {
        public User()
        {
            Companies = new HashSet<Company>();
            Customers = new HashSet<Customer>();
            DeliveryDetailParticulars = new HashSet<DeliveryDetailParticular>();
            DeliveryDetails = new HashSet<DeliveryDetail>();
            PurchaseDetailParticulars = new HashSet<PurchaseDetailParticular>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNoCode { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<DeliveryDetailParticular> DeliveryDetailParticulars { get; set; }
        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }
        public virtual ICollection<PurchaseDetailParticular> PurchaseDetailParticulars { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
