﻿using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
         public DateTime CreatedAt { get; set; }
    }
}
