using Financial.Domain.Entities;
using Financial.Domain.Filter;
using Financial.Domain.Pagination;

namespace Financial.Domain.Interfaces
{
    public interface IMovementRepository : IGenericRepository<Movement>
    {
        Task<PageList<Movement>> GetByUserId(PageParams pageParams, MovementFilter movimentFilter, long userId);
        Task<Movement> GetById(long id, long userId);
        Task<IEnumerable<Movement>> GetTotalMovementByType(long userId, string charPaymentType);
    }
}