using Amazon.Runtime.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    readonly IMongoCollection<User> _collection;
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

    public async Task AddTransactionToGoalAsync(Guid userId, Guid goalId, Transaction transaction)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Goals, g => g.Id == goalId));

        var updateUser = Builders<User>.Update.Push("Goals.$.Transactions", transaction);

        await _collection.UpdateOneAsync(filter, updateUser);
    }

    public async Task UpdateTransactionToGoalAsync(Guid userId, Guid goalId, Transaction transaction)
    {
        // Filtro do documento User
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);

        // Atualização: set na transaction certa dentro do goal certo
        var update = Builders<User>.Update
            .Set("Goals.$[goal].Transactions.$[tran]", transaction);

        // Filtros para os arrays (Goals e Transactions)
        var arrayFilters = new List<ArrayFilterDefinition>
        {
            // Filtra o Goal correto
            new BsonDocumentArrayFilterDefinition<BsonDocument>(
                new BsonDocument("goal.Id", goalId)
            ),
            // Filtra a Transaction correta dentro do Goal
            new BsonDocumentArrayFilterDefinition<BsonDocument>(
                new BsonDocument("tran.Id", transaction.Id)
            )
        };

        var options = new UpdateOptions
        {
            ArrayFilters = arrayFilters
        };

        await _collection.UpdateOneAsync(filter, update, options);
    }
}
