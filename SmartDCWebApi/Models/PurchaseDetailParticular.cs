using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class PurchaseDetailParticular
    {
        public int PurchaseDetailParticularId { get; set; }
        public int PurchaseId { get; set; }
        public int SerialNo { get; set; }
        public string Particulars { get; set; }
        public string WashType { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Status { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual PurchaseDetail Purchase { get; set; }
    }
}
