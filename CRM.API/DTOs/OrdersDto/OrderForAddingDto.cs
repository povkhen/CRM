using System;

namespace CRM.API.DTOs
{
    public class OrderForAddingDto
    {
        public string Number { get; set; }
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
        public virtual int? OrderId { get; set; }
        public virtual int? ExecutorId { get; set; }
        public virtual int? PaymentId { get; set; }
    }
}