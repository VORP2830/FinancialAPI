using Financial.Domain.Entities;
using Financial.Domain.Filter;
using Financial.Domain.Interfaces;
using Financial.Domain.Pagination;
using Financial.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Financial.Infra.Data.Repositories
{
    public class MovementRepository : GenericRepository<Movement>, IMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public MovementRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }

        public async Task<Movement> GetById(long id, long userId)
        {
            return await _context.Movements
                                    .FirstOrDefaultAsync(m => m.Active == true && m.Id == id && m.UserId == userId);
        }
        public async Task<PageList<Movement>> GetByUserId(PageParams pageParams, MovementFilter movementFilter, long userId)
        {
            var query = _context.Movements
                            .Where(m => m.UserId == userId && m.Active == true);
            
            if(!string.IsNullOrEmpty(movementFilter.Description))
            {
                query = query.Where(a => a.Description.ToLower().Contains(movementFilter.Description.ToLower()));
            }
            if (movementFilter.CreatedAt.HasValue)
            {
                query = query.Where(a => a.PaymentDate.Date >= movementFilter.CreatedAt.Value.Date);
            }
            if (movementFilter.CreatedUntil.HasValue)
            {
                query = query.Where(a => a.PaymentDate.Date <= movementFilter.CreatedUntil.Value.Date);
            }
            
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                                .Take(pageParams.PageSize)
                                .ToListAsync();
            
            return new PageList<Movement>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<IEnumerable<Movement>> GetTotalMovementByType(long userId, string charPaymentType)
        {
            return await _context.Movements.Where(m => m.Active == true && m.CharPaymentType == charPaymentType && m.UserId == userId).ToListAsync();
        }
    }
}