namespace Financial.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IMovementRepository MovementRepository { get; }
        Task<bool> SaveChangesAsync();  
    }
}