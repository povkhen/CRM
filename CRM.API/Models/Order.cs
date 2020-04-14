using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public partial class Order
    {
        public Order()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte DeliveryStatus { get; set; }
        public int OwnerId { get; set; }
        public int? DeliveryDriverId { get; set; }
        public string DeliveryAddress { get; set; }
        public int? ReceiverId { get; set; }
        public string Comment { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public decimal? Sum { get; set; }
        public byte PaymentStatus { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
