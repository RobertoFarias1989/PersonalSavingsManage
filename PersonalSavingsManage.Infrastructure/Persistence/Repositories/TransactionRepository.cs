using MongoDB.Driver;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IMongoCollection<Transaction> _collection;
    public TransactionRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Transaction>("transactions");
    }
    public async Task<List<Transaction>> GetAllAsync()
    {
        return await _collection.Find(t => true).ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(string id)
    {
        return await _collection.Find(t => t.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddAsync(Transaction transaction)
    {
        await _collection.InsertOneAsync(transaction);
    }

}
