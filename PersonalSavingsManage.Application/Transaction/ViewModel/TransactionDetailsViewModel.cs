namespace PersonalSavingsManage.Application.Transaction.ViewModel;

public class TransactionDetailsViewModel
{
    public TransactionDetailsViewModel(Guid id,
        decimal amount, string type, DateTime transactionDate, bool isDeleted, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Amount = amount;
        Type = type;
        TransactionDate = transactionDate;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Type { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static TransactionDetailsViewModel FromEntity(Core.Entities.Transaction entity)
    {
        return new TransactionDetailsViewModel(entity.Id, entity.Amount, entity.Type.ToString(), entity.TransactionDate, entity.IsDeleted, entity.CreatedAt, entity.UpdatedAt);
    }
}
