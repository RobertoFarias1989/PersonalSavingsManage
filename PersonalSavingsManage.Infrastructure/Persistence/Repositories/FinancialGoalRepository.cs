using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class FinancialGoalRepository : IFinancialGoalRepository
{


    public Task<List<FinancialGoal>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FinancialGoal> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<FinancialGoal> GetDetailsByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
    public Task AddAsync(FinancialGoal goal)
    {
        throw new NotImplementedException();
    }
}
