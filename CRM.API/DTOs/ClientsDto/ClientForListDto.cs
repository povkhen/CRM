using System;

namespace CRM.API.DTOs
{
    public class ClientForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int OrdersCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}