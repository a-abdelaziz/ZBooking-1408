﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBooking.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id;
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}
