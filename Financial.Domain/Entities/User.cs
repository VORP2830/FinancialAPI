using System.Text.RegularExpressions;
using Financial.Domain.Exceptions;

namespace Financial.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public IEnumerable<Movement> Movements { get; set; }
        protected User(){ }
        public User(string name, string userName, string password)
        {
            ValidateDomain(name, userName, password);
            Active = true;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        private void ValidateDomain(string name, string userName, string password)
        {
            FinancialException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            FinancialException.When(name.Length < 3, "Nome deve conter mais de 3 caracteres");
            FinancialException.When(string.IsNullOrEmpty(password), "Senha é obrigatória");
            Name = name.Trim();
            UserName = userName.Trim().ToLower();
            Password = password;
        }
    }
}