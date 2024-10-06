using MongoDB.Driver;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class FinancialGoalRepository : IFinancialGoalRepository
{
    private readonly IMongoCollection<FinancialGoal> _collection;
    public FinancialGoalRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<FinancialGoal>("financialgoals");
    }

    public async Task<List<FinancialGoal>> GetAllAsync()
    {
       return await _collection.Find(fg => true).ToListAsync();
    }

    public async Task<FinancialGoal> GetByIdAsync(string id)
    {
        return await _collection.Find(fg => fg.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddAsync(FinancialGoal goal)
    {
        await _collection.InsertOneAsync(goal);
    }

    public async Task UpdateAsync(FinancialGoal goal)
    {
        await _collection.ReplaceOneAsync(fg => fg.Id == goal.Id, goal);    
    }
}
