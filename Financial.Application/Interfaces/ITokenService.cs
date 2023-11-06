namespace Financial.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(long userId, string userName);
    }
}