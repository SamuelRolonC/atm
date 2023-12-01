namespace Core
{
    public class SystemParameters
    {
        public struct OperationType
        {
            public const string Withdrawal = "RETIRO";
            public const string Balance = "BALANCE";
        }

        public struct Card
        {
            public const int MaxFailedAttempts = 3;
        }

        public struct ConnectionString
        {
            public const string AtmContext = "AtmContext";
        }
    }
}
