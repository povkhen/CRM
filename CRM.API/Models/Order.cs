using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte ExecutionStatus { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string Comment { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public decimal? Sum { get; set; }

        public virtual int? VendorId { get; set; }
        public virtual User Vendor { get; set; }
        public virtual int? ExecutorId { get; set; }
        public virtual User Executor { get; set; }
        public virtual int OwnerId { get; set; }
        public virtual Customer Owner { get; set; }
        public virtual int? PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
