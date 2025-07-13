using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Application.Transaction.ViewModel;

public class TransactionViewModel
{
    public TransactionViewModel(string id, decimal amount, string type, DateTime transactionDate)
    {
        Id = id;
        Amount = amount;
        Type = type;
        TransactionDate = transactionDate;
    }

    public string Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Type { get; private set; }
    public DateTime TransactionDate { get; private set; }

    public static TransactionViewModel FromEntity(Core.Entities.Transaction entity) 
    {
        return new TransactionViewModel(entity.Id, entity.Amount, entity.Type.ToString(), entity.TransactionDate);
    }
}
