using Core.Entities;

namespace Tests.Data
{
    public class CardData
    {

        public static Card GetCardActive()
        {
            return new Card
            {
                Id = 1,
                Number = "1111222233334444",
                Pin = "1234",
                Balance = 1000,
                IsBlocked = false,
                Active = true,
                CreatedAt = DateTime.Now,
            };
        }

        public static Card GetCardNonActive()
        {
            return new Card
            {
                Id = 2,
                Number = "2111222233334444",
                Pin = "1234",
                Balance = 1000,
                IsBlocked = false,
                Active = false,
                CreatedAt = DateTime.Now,
            };
        }

        public static IEnumerable<Card> GetCards()
        {
            return new List<Card>
            {
                GetCardActive(),
                GetCardNonActive()
            };
        }
    }
}
