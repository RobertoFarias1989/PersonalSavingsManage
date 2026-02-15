using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Core.Entities;

public class Transaction : BaseEntity
{
    public Transaction()
    {
        ///ef core
    }
    public Transaction(decimal amount, TransactionTypeEnum type, int idUser, int idGoal) : base()
    {
        Amount = amount;
        Type = type;
        IdUser = idUser;
        IdGoal = idGoal;

        TransactionDate = DateTime.Now;
    }

    public decimal Amount { get; private set; }
    public TransactionTypeEnum Type { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
    public int IdGoal { get; private set; }
    public Goal Goal { get; private set; }

    public void Update(decimal amount, TransactionTypeEnum type)
    {
        Amount = amount;
        Type = type;

        //TODO: ver se faz sentido permitir mudar o Type da Transaction
        //se sim, ver tratamento para o impacto disso no saldo do FinancialGoal

        UpdatedAt = DateTime.Now;
    }
}
