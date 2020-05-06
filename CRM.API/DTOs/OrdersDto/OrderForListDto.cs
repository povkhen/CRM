using System;

namespace CRM.API.DTOs
{
    public class OrderForListDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte ExecutionStatus { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public decimal? Sum { get; set; }

    }
}