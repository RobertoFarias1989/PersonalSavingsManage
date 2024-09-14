using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface IFinancialGoalRepository
{
    public Task<List<FinancialGoal>> GetAllAsync();
    public Task<FinancialGoal> GetByIdAsync(string id);
    public Task<FinancialGoal> GetDetailsByIdAsync(string id);
    public Task AddAsync(FinancialGoal goal);
}
