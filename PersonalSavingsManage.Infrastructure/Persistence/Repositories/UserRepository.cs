using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public Task Addasync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
