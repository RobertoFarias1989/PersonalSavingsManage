namespace PersonalSavingsManage.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
        IsDeleted = false;
        UpdatedAt = null;
    }

    public string Id { get; protected set; } = string.Empty;
    public bool IsDeleted { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    public virtual void SetAsDelete()
    {
        IsDeleted = true;

        UpdatedAt = DateTime.Now;
    }
}
