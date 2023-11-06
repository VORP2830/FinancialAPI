namespace Financial.Application.DTOs
{
    public class MovementDTO
    {
        public long Id { get; set; }
        public string Description { get; set; } 
        public DateTime PaymentDate { get; set; } 
        public string CharPaymentType { get; set; } 
        public double Value { get; set; } 
    }
}