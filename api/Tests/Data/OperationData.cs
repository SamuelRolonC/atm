using Core.Entities;

namespace Tests.Data
{
    public class OperationData
    {
        public static Operation GetOperationBalance()
        {
            return new Operation
            {
                Id = 1,
                CardId = 1,
                Amount = 1000,
                DateTime = DateTime.Now,
                OperationTypeId = 1,
            };
        }

        public static Operation GetOperationWithdrawal()
        {
            return new Operation
            {
                Id = 2,
                CardId = 1,
                Amount = 100,
                DateTime = DateTime.Now,
                OperationTypeId = 1
            };
        }

        public static Operation GetOperationDeposit()
        {
            return new Operation
            {
                Id = 3,
                CardId = 1,
                Amount = 100,
                DateTime = DateTime.Now,
                OperationTypeId = 1,
            };
        }

        public static IEnumerable<Operation> GetOperations()
        {
            return new List<Operation>
            {
                GetOperationBalance(),
                GetOperationWithdrawal(),
                GetOperationDeposit(),
            };
        }
    }
}
