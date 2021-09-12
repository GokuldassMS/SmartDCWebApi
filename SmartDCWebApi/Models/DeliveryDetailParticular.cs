using System;
using System.Collections.Generic;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class DeliveryDetailParticular
    {
        public int DeliveryDetailParticularId { get; set; }
        public int DeliveryId { get; set; }
        public int SerialNo { get; set; }
        public string Particulars { get; set; }
        public string WashType { get; set; }
        public int ReturnQuantity { get; set; }
        public int? PendingQuantity { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Status { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual DeliveryDetail Delivery { get; set; }
    }
}
