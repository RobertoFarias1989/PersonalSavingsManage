using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task<User> GetUserByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}
