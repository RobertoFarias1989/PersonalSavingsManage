using Microsoft.EntityFrameworkCore;
using PersonalSavingsManage.Core.Entities;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Infrastructure.Persistence.Repositories;

public class GoalRepository : IGoalRepository
{
    private readonly PersonalSavingsDbContext _context;

    public GoalRepository(PersonalSavingsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Goal>> GetAllAsync()
    {
        return await _context.Goals
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Goal?> GetByIdAsync(int id)
    {
        return await _context.Goals
            .Include(g => g.Transactions)            
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task AddAsync(Goal goal)
    {
        await _context.Goals.AddAsync(goal);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Goal goal)
    {
        _context.Goals.Update(goal);

        await _context.SaveChangesAsync();
    }
    
}
