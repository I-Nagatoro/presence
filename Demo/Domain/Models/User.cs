﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.domain.Models
{
    public class User
    {
        public required string FIO { get; set; }
        public Guid Guid { get; set; }
        public int ID { get; set; }
        public required Group Group { get; set; }
    }
}