using AutoMapper;
using Financial.Application.DTOs;
using Financial.Application.Interfaces;
using Financial.Domain.Entities;
using Financial.Domain.Exceptions;
using Financial.Domain.Filter;
using Financial.Domain.Interfaces;
using Financial.Domain.Pagination;

namespace Financial.Application.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MovementService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PageList<MovementDTO>> GetAllPaged(PageParams pageParams, MovementFilter movementFilter, long userId)
        {
            PageList<Movement> movements = await _unitOfWork.MovementRepository.GetByUserId(pageParams, movementFilter, userId);
            var movementsDTO = _mapper.Map<IEnumerable<MovementDTO>>(movements.Items);
            return new PageList<MovementDTO>(movementsDTO.ToList(), movements.TotalCount, movements.CurrentPage, movements.PageSize);
        }
        public async Task<MovementDTO> GetById(long id, long userId)
        {
            Movement movement = await _unitOfWork.MovementRepository.GetById(id, userId);
            if(movement == null) throw new FinancialException("Movimentação não encontrada");
            return _mapper.Map<MovementDTO>(movement);
        }
        public async Task<MovementDTO> Create(MovementDTO model, long userId)
        {
            Movement movement = _mapper.Map<Movement>(model);
            movement.SetUserId(userId);
            movement.SetActive(true);
            _unitOfWork.MovementRepository.Add(movement);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MovementDTO>(movement);
        }
        public async Task<MovementDTO> Update(MovementDTO model, long userId)
        {
            Movement movement = await _unitOfWork.MovementRepository.GetById(model.Id, userId);
            if(movement == null) throw new FinancialException("Movimentação não encontrada");
            _mapper.Map(movement, model);
            _unitOfWork.MovementRepository.Update(movement);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MovementDTO>(movement);
        }
        public async Task<MovementDTO> Delete(long id, long userId)
        {
            Movement movement = await _unitOfWork.MovementRepository.GetById(id, userId);
            if(movement == null) throw new FinancialException("Movimentação não encontrada");
            movement.SetActive(false);
            _unitOfWork.MovementRepository.Update(movement);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MovementDTO>(movement);
        }

        public async Task<object> GetBalance(long userId)
        {
            double total = 0;
            IEnumerable<Movement> movementsRevenue = await _unitOfWork.MovementRepository.GetTotalMovementByType(userId, "R");
            IEnumerable<Movement> movementExpense = await _unitOfWork.MovementRepository.GetTotalMovementByType(userId, "D");
            foreach(Movement movement in movementsRevenue)
            {
                total += movement.Value;
            }
            foreach(Movement movement in movementExpense)
            {
                total -= movement.Value;
            }
            var response = new
            {
                Balance = total,
            };
            return response;
        }
    }
}