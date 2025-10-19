using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface IFinancialGoalRepository
{
    Task<List<FinancialGoal>> GetAllAsync();
    Task<FinancialGoal> GetByIdAsync(Guid id);
    Task AddAsync(FinancialGoal goal);
    Task UpdateAsync(FinancialGoal goal);
}
