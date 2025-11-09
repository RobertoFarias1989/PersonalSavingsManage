using Amazon.Runtime.Internal;
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

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _collection.Find(u => u.Id == id).SingleOrDefaultAsync();
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _collection
            .Find(u => u.Email.EmailAddress == email && u.Password.PasswordValue == passwordHash)
            .SingleOrDefaultAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _collection
          .Find(u => u.Email.EmailAddress == email)
          .SingleOrDefaultAsync();
    }

    public async Task AddAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    public async Task AddGoalToUserAsync(Guid userId, FinancialGoal goal)
    {
        var filterUser = Builders<User>.Filter.Eq(u => u.Id, userId);

        var updateUser = Builders<User>.Update.Push(u => u.Goals, goal);

        await _collection.UpdateOneAsync(filterUser, updateUser);
    }

    public async Task<FinancialGoal> GetUserGoalAsync(Guid userId, Guid goalId)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Goals, g => g.Id == goalId && g.IsDeleted != true));

        var projection = Builders<User>.Projection
            .ElemMatch(u => u.Goals, g => g.Id == goalId);

        var partialUser = await _collection
            .Find(filter)
            .Project<User>(projection)
            .SingleOrDefaultAsync();

        return partialUser?.Goals?.SingleOrDefault();

    }

    public async Task UpdateGoalToUserAsync(Guid userId, FinancialGoal goal)
    {
        var userFilter = Builders<User>.Filter.Eq(u => u.Id, userId);

        var updateGoal = Builders<User>.Update.Set("Goals.$[g]", goal);

        await _collection.UpdateOneAsync(userFilter, updateGoal);
    }
}
