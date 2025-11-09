using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
        IsDeleted = false;
        UpdatedAt = null;
    }

    public Guid Id { get; protected set; } = Guid.NewGuid();
    public bool IsDeleted { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    public virtual ResultViewModel SetAsDelete()
    {
        IsDeleted = true;

        UpdatedAt = DateTime.Now;

        return ResultViewModel.Success();
    }
}
