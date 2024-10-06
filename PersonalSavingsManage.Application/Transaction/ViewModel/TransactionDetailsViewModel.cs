namespace PersonalSavingsManage.Application.Transaction.ViewModel;

public class TransactionDetailsViewModel
{
    public TransactionDetailsViewModel(string id,
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

    public string Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Type { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
}
