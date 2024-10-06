using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Core.Entities;

public class User : BaseEntity
{
    public User(Address address, Email email, Name name, Password password, string role) : base()
    {
        Address = address;
        Email = email;
        Name = name;
        Password = password;
        Role = role;

        Goals = new List<FinancialGoal>();
        Transactions = new List<Transaction>();
    }

    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Name Name { get; private set; }
    public Password Password { get; private set; }
    public string Role { get; private set; }
    public List<FinancialGoal>  Goals { get; private set; }
    public List<Transaction>  Transactions { get; private set; }

    public void Update(Address address, Email email, Name name, Password password)
    {
        Address = address;
        Email = email;
        Name = name;
        Password = password;

        UpdatedAt = DateTime.Now;
    }
}
