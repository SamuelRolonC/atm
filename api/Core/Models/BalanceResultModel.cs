namespace Core.Models
{
    public class BalanceResultModel
    {
        public string CardNumber { get; set; } = string.Empty;
        public string CardDueDate { get; set; } = string.Empty;
        public decimal CardBalance { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
