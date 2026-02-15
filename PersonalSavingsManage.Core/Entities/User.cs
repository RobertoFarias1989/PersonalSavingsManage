using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Core.Entities;

public class User : BaseEntity
{
    public User()
    {
        ///ef core
    }
    public User(Address address, Email email, Name name, Password password, string role) : base()
    {
        Address = address;
        Email = email;
        Name = name;
        Password = password;
        Role = role;

        Goals = new List<Goal>();
        Transactions = new List<Transaction>();
    }

    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Name Name { get; private set; }
    public Password Password { get; private set; }
    public string Role { get; private set; }
    public List<Goal>  Goals { get; private set; }
    public List<Transaction>  Transactions { get; private set; }

    public void Update(Address address, Email email, Name name, Password password)
    {
        Address = address;
        Email = email;
        Name = name;
        Password = password;

        UpdatedAt = DateTime.Now;
    }

    public void UpdatePassword(Password password)
    {
        Password = password;
    }
}
