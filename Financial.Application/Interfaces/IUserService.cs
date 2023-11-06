using Financial.Application.DTOs;

namespace Financial.Application.Interfaces
{
    public interface IUserService
    {
        Task<Object> Register(UserDTO model);
        Task<Object> Login(UserLoginDTO model);
        Task<Object> Update(UserDTO model, long userId);
        Task<UserDTO> Get(long userId);
    }
}