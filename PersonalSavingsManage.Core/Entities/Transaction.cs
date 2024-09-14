using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Core.Entities;

public class Transaction : BaseEntity
{
    public Transaction(decimal amount, TransactionTypeEnum type, DateTime transactionDate) : base()
    {
        Amount = amount;
        Type = type;
        TransactionDate = transactionDate;
    }

    public decimal Amount { get; private set; }
    public TransactionTypeEnum Type { get; private set; }
    public DateTime TransactionDate { get; private set; }
}
