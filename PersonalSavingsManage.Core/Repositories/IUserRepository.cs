using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(string id);
    Task<User> GetDetailsByIdAsync(string id);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task Addasync(User user);

}
