using MongoDB.Driver;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;
    public UserRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<User>("users");
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _collection.Find(u => true).ToListAsync();
    }

    public async Task<User> GetByIdAsync(string id)
    {
        return await _collection.Find(u => u.Id == id).SingleOrDefaultAsync();
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _collection
            .Find(u => u.Email.EmailAddress == email && u.Password.PasswordValue == passwordHash)
            .SingleOrDefaultAsync();
    }
    public async Task Addasync(User user)
    {
        await _collection.InsertOneAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }
}
