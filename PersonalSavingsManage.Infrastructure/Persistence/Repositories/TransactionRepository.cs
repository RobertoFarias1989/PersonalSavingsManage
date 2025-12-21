using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public Task AddAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<List<Transaction>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}
