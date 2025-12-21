namespace PersonalSavingsManage.Application.Transaction.ViewModel;

public class TransactionDetailsViewModel
{
    public TransactionDetailsViewModel(int id,
        decimal amount, string type, DateTime transactionDate, int idUser, int idGoal, bool isDeleted, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Amount = amount;
        Type = type;
        TransactionDate = transactionDate;
        IdUser = idUser;
        IdGoal = idGoal;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Type { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public int IdUser { get; private set; }
    public int IdGoal { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static TransactionDetailsViewModel FromEntity(Core.Entities.Transaction entity)
    {
        return new TransactionDetailsViewModel(entity.Id, entity.Amount, entity.Type.ToString(), entity.TransactionDate,
            entity.IdUser, entity.IdGoal, entity.IsDeleted, entity.CreatedAt, entity.UpdatedAt);
    }
}
