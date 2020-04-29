using System;
using System.Collections.Generic;
using CRM.API.Models;

namespace CRM.API.DTOs
{
    public class ClientForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<OrderForClientDto> Orders { get; set; }
    }
}