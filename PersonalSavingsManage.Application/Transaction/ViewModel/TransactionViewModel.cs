namespace PersonalSavingsManage.Application.Transaction.ViewModel;

public class TransactionViewModel
{
    public TransactionViewModel(int id, decimal amount, string type, DateTime transactionDate, int idUser, int idGoal)
    {
        Id = id;
        Amount = amount;
        Type = type;
        TransactionDate = transactionDate;
        IdUser = idUser;
        IdGoal = idGoal;
    }

    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Type { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public int IdUser { get; private set; }
    public int IdGoal { get; private set; }

    public static TransactionViewModel FromEntity(Core.Entities.Transaction entity)
    {
        return new TransactionViewModel(entity.Id, entity.Amount, entity.Type.ToString(), entity.TransactionDate,
            entity.IdUser, entity.IdGoal);
    }
}
