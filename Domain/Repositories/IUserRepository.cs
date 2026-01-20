namespace SubscriptionManagementSystem.Domain.Repositories
{
    
    public interface IUserRepository
    {
        Task<long> AddAsync(User user);
        Task DeleteAsync(long id);
        Task<List<User>> GetAllAsync();
        
        Task<bool> EmailExistsAsync(string email);
        Task<User> GetByIdAsync(long id);
    }
    
}
