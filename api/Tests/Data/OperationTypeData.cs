using Core.Entities;

namespace Tests.Data
{
    public class OperationTypeData
    {
        public static OperationType GetOperationTypeBalance()
        {
            return new OperationType
            {
                Id = 1,
                Description = "Balance",
            };
        }

        public static OperationType GetOperationTypeWithdrawal()
        {
            return new OperationType
            {
                Id = 2,
                Description = "Withdrawal",
            };
        }

        public static OperationType GetOperationTypeDeposit()
        {
            return new OperationType
            {
                Id = 3,
                Description = "Deposit",
            };
        }

        public static IEnumerable<OperationType> GetOperationTypes()
        {
            return new List<OperationType>
            {
                GetOperationTypeBalance(),
                GetOperationTypeWithdrawal(),
                GetOperationTypeDeposit(),
            };
        }
    }
}
