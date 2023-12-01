using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmTests.Data
{
    public class CardNumberResultModelData
    {
        public static CardNumberResultModel GetValid()
        {
            return new CardNumberResultModel()
            {
                CardId = 1,
                IsValid = true,
                Message = string.Empty
            };
        }

        public static CardNumberResultModel GetNonValid()
        {
            return new CardNumberResultModel()
            {
                CardId = 0,
                IsValid = false,
                Message = "An error occured."
            };
        }
    }
}
