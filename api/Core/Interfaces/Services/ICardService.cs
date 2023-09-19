using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICardService
    {
        public Task<CardNumberResultModel> ValidateNumberAsync(string number);
        public Task<CardPinResultModel> ValidatePinAsync(int id, string pin);
        public Task SetHashField();
    }
}
