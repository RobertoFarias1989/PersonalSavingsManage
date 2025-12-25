using Microsoft.EntityFrameworkCore;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{    
    private readonly PersonalSavingsDbContext _context;

    public UserRepository(PersonalSavingsDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Goals)
            .Include(u => u.Transactions)
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        throw new NotImplementedException();
    }

    public async Task Addasync(User user)
    {
       await _context.Users.AddAsync(user);

       await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);

        await _context.SaveChangesAsync();
    }
}
