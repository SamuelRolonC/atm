﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ValidateCardResultModel
    {
        public bool IsValid { get; set; }
        public string? Message { get; set; } = string.Empty;
    }
}
