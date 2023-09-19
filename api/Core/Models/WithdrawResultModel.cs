﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class WithdrawResultModel
    {
        public string CardNumber { get; set; } = string.Empty;
        public decimal CardBalance { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal OperationAmount { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}