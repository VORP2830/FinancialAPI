using Financial.Domain.Entities;

namespace Financial.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetById(long id);
    }
}