using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
           _context = context;
        }
        public async Task<long> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;

        }

        public async Task DeleteAsync(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

        }

        public Task<bool> EmailExistsAsync(string email)
        {
            return _context.Users.AnyAsync(u => u.Email == email);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.AsNoTracking().ToListAsync();
        }

        public Task<User> GetByIdAsync(long id)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
