using System;

namespace CRM.API.DTOs
{
    public class OrderForClientDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte ExecutionStatus { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}