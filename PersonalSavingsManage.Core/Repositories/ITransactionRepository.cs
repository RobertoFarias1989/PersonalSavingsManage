using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Core.Repositories;

public interface ITransactionRepository
{
    public Task<List<Transaction>> GetAllAsync();
    public Task<Transaction> GetByIdAsync(string id);
    public Task<Transaction> GetDetailsByIdAsync(string id);
    public Task AddAsync(Transaction transaction);
}
