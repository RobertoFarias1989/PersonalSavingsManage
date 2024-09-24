using MongoDB.Driver;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;
    public UserRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<User>("users");
    }
    public async Task<List<User>> GetAllAsync()
    {
        //não entendi muito bem o porquê de ter que passar este u => true dentro do find;
        return await _collection.Find(u => true).ToListAsync();
    }

    public async Task<User> GetByIdAsync(string id)
    {
        //Perguntar no encontro de terça o porquê de não usar este método
        //await _collection.FindAsync(u => u.Id == id);

        return await _collection.Find(u => u.Id == id).SingleOrDefaultAsync();
    }

    public Task<User> GetDetailsByIdAsync(string id)
    {
        throw new NotImplementedException();
        //Faz sentido eu ter um método de detalhes já que a collection por Id já traz o objeto todo?
        //O Details é usado no EF core para include algumas entidades de navegação aqui com o mongo não temos isso?
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _collection
            .Find(u => u.Email.EmailAddress == email && u.Password.PasswordValue == passwordHash)
            .SingleOrDefaultAsync();
    }
    public async Task Addasync(User user)
    {
        await _collection.InsertOneAsync(user);
    }
}
