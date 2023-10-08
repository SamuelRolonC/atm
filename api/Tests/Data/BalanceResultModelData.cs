using Core.Models;

namespace AtmTests.Data
{
    public class BalanceResultModelData
    {
        public static BalanceResultModel GetSuccess()
        {
            return new BalanceResultModel()
            {
                CardNumber = "1234567890123456",
                CardDueDate = "10/12/2020",
                CardBalance = 100,
                Success = true,
                Message = string.Empty
            };
        }

        public static BalanceResultModel GetNonSuccess()
        {
            return new BalanceResultModel()
            {
                CardNumber = string.Empty,
                CardDueDate = string.Empty,
                CardBalance = 0,
                Success = false,
                Message = "An error ocurred."
            };
        }
    }
}
