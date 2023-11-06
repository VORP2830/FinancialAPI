using Financial.Domain.Entities;
using Financial.Domain.Interfaces;
using Financial.Infra.Data.Context;

namespace Financial.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => new UserRepository(_context);

        public IMovementRepository MovementRepository => new MovementRepository(_context);

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}