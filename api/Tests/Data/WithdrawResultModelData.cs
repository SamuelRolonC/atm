using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmTests.Data
{
    public class WithdrawResultModelData
    {
        public static WithdrawResultModel GetSuccess()
        {
            return new WithdrawResultModel()
            {
                CardNumber = "1234567890123456",
                CardBalance = 100,
                OperationDate = "10/12/2020 10:00:00",
                OperationAmount = 50,
                Success = true,
                Message = string.Empty
            };
        }

        public static WithdrawResultModel GetNonSuccess()
        {
            return new WithdrawResultModel()
            {
                CardNumber = string.Empty,
                CardBalance = 0,
                OperationDate = string.Empty,
                OperationAmount = 0,
                Success = false,
                Message = "An error ocurred."
            };
        }
    }
}
