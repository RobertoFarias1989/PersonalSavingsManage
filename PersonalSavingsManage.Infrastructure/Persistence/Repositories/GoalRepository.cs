using MongoDB.Driver;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class GoalRepository : IGoalRepository
{
    private readonly IMongoCollection<Goal> _collection;
    public GoalRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Goal>("financialgoals");
    }

    public async Task<List<Goal>> GetAllAsync()
    {
       return await _collection.Find(fg => true).ToListAsync();
    }

    public async Task<Goal> GetByIdAsync(string id)
    {
        return await _collection.Find(fg => fg.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddAsync(Goal goal)
    {
        await _collection.InsertOneAsync(goal);
    }

    public async Task UpdateAsync(Goal goal)
    {
        await _collection.ReplaceOneAsync(fg => fg.Id == goal.Id, goal);    
    }
}
