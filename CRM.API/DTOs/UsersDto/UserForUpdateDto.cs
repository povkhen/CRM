using System;
using System.Collections.Generic;
using CRM.API.Models;

namespace CRM.API.DTOs
{
    public class UserForUpdateDto
    {   
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}