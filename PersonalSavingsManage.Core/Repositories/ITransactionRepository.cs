using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetAllAsync();
    Task<Transaction> GetByIdAsync(string id);
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
}
