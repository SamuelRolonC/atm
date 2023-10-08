using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Data
{
    public class CardData
    {

        public static Card GetCardExampleOne()
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

        public static Card GetCardExampleTwo()
        {
            return new Card
            {
                Id = 2,
                Number = "2111222233334444",
                Pin = "1234",
                Balance = 1000,
                CreatedAt = DateTime.Now,
            };
        }

        public static IEnumerable<Card> GetCards()
        {
            return new List<Card>
            {
                GetCardExampleOne(),
                GetCardExampleTwo()
            };
        }
    }
}
