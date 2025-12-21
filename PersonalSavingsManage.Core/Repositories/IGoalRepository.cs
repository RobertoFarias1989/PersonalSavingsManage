using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface IGoalRepository
{
    Task<List<Goal>> GetAllAsync();
    Task<Goal> GetByIdAsync(int id);
    Task AddAsync(Goal goal);
    Task UpdateAsync(Goal goal);
}
