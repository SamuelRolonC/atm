using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CardService : ICardService
    {
        public readonly SetAttempts _cardRepository;

        public CardService(SetAttempts cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardNumberResultModel> ValidateNumberAsync(string number)
        {
            return await _cardRepository.ValidateNumberAsync(number);
        }

        public async Task<ValidateCardResultModel> ValidatePinAsync(int id, string pin)
        {
            var resultModel = await _cardRepository.ValidatePinAsync(id, pin);
            if (resultModel == null)
                throw new Exception("Card not found.");

            await _cardRepository.SetAttempts(id, resultModel.IsValid);

            return resultModel;
        }
    }
}
