using Financial.Application.DTOs;
using Financial.Domain.Filter;
using Financial.Domain.Pagination;

namespace Financial.Application.Interfaces
{
    public interface IMovementService
    {
        Task<PageList<MovementDTO>> GetAllPaged(PageParams pageParams, MovementFilter movimentFilter, long userId);
        Task<MovementDTO> GetById(long id, long userId);
        Task<MovementDTO> Create(MovementDTO model, long userId);
        Task<MovementDTO> Update(MovementDTO model, long userId);
        Task<MovementDTO> Delete(long id, long userId);
        Task<object> GetBalance(long userId);
    }
}