namespace Core.Models
{
    public class CardNumberResultModel
    {
        public int CardId { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
