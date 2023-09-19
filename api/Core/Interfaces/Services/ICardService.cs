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
        public Task<ValidateCardResultModel> ValidatePinAsync(int id, string pin);
    }
}
