using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class GoalRepository : IGoalRepository
{
    public Task AddAsync(Goal goal)
    {
        throw new NotImplementedException();
    }

    public Task<List<Goal>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Goal> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Goal goal)
    {
        throw new NotImplementedException();
    }
}
