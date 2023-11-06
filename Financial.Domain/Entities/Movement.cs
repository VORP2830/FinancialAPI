using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities
{
    public class Movement : BaseEntity
    {
        public string Description { get; protected set; } 
        public DateTime PaymentDate { get; protected set; } 
        public string CharPaymentType { get; protected set; } 
        public double Value { get; protected set; } 
        public long UserId { get; protected set; }
        public User User { get; set; } 
        protected Movement(){ }
        public void SetUserId(long userId)
        {
            UserId = userId;
        }
        public Movement(string description, DateTime paymentDate, string charPaymentType, double value, long userId)
        {
            ValidateDomain(description, paymentDate, charPaymentType, value, userId);
            Active = true;
        }
        private void ValidateDomain(string description, DateTime paymentDate, string charPaymentType, double value, long userId)
        {
            FinancialException.When(string.IsNullOrEmpty(description), "A descrição é obrigatória");
            FinancialException.When(description.Length < 3, "A descrição deve conter mais de 3 caracteres");
            FinancialException.When(string.IsNullOrEmpty(value.ToString()), "O Valor é obrigatório");
            FinancialException.When(charPaymentType != "R", "Tipo de pagamento deve ser R para receita ou D para despesa");
            FinancialException.When(charPaymentType != "D", "Tipo de pagamento deve ser R para receita ou D para despesa");
            FinancialException.When(value <= 0, "O valor não pode ser negativo");
            FinancialException.When(userId < 0, "UserId inválido");
            Description = description.Trim();
            PaymentDate = paymentDate;
            CharPaymentType = charPaymentType;
            Value = value;
            UserId = userId;
        }
    }
}