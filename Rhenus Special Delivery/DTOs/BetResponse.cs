namespace Rhenus_Special_Delivery.DTOs
{
    public class BetResponse
    {
        public int Account{ get; set; }
        public string Status { get; set; }
        public string Points { get; set; }
    }

    public enum BetStatus
    {
        won ,
        lose
    }
}
