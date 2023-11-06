using Financial.API.Extensions;
using Financial.Application.DTOs;
using Financial.Application.Interfaces;
using Financial.Domain.Exceptions;
using Financial.Domain.Filter;
using Financial.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financial.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;
        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MovementFilter movementFilter, [FromQuery] PageParams pageParams)
        {
            try
            {
                var result = await _movementService.GetAllPaged(pageParams, movementFilter, User.GetUserId());
                return Ok(result);
            }
            catch(FinancialException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar movimentações",
                                        detail = ex.Message
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _movementService.GetById(id, User.GetUserId());
                return Ok(result);
            }
            catch(FinancialException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar movimentação",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetBalance")]
        public async Task<IActionResult> GetBalance()
        {
            try
            {
                var result = await _movementService.GetBalance(User.GetUserId());
                return Ok(result);
            }
            catch(FinancialException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar saldo",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovementDTO model)
        {
            try
            {
                var result = await _movementService.Create(model, User.GetUserId());
                return Ok(result);
            }
            catch(FinancialException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar criar movimentação"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(MovementDTO model)
        {
            try
            {
                var result = await _movementService.Update(model, User.GetUserId());
                return Ok(result);
            }
            catch(FinancialException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar alualizar movimentação",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _movementService.Delete(id, User.GetUserId());
                return Ok(result);
            }
            catch(FinancialException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar deletar movimentação",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}