﻿using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public byte? Status { get; set; }
        public decimal? Sum { get; set; }
        public byte? Method { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
