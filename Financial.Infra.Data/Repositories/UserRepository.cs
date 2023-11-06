using Financial.Domain.Entities;
using Financial.Domain.Interfaces;
using Financial.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financial.Infra.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
        public async Task<User> GetById(long id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
        }
    }
}