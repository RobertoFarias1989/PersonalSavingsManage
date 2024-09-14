using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface IFinancialGoalRepository
{
    Task<List<FinancialGoal>> GetAllAsync();
    Task<FinancialGoal> GetByIdAsync(string id);
    Task<FinancialGoal> GetDetailsByIdAsync(string id);
    Task AddAsync(FinancialGoal goal);
}
