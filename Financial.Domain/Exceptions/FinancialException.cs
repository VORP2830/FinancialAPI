namespace Financial.Domain.Exceptions
{
    public class FinancialException : Exception
    {
        public FinancialException(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new FinancialException(error);
            }
        }
    }
}