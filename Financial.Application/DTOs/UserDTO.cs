namespace Financial.Application.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}