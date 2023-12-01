using Core.Models;

namespace AtmTests.Data
{
    public class CardPinResultModelData
    {
        public static CardPinResultModel GetValid()
        {
            return new CardPinResultModel()
            {
                CardId = 1,
                IsValid = true,
                Message = string.Empty
            };
        }

        public static CardPinResultModel GetNonValid()
        {
            return new CardPinResultModel()
            {
                CardId = 0,
                IsValid = false,
                Message = "An error occured."
            };
        }
    }
}
