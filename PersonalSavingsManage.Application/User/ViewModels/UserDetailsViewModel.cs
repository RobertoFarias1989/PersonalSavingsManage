using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.User.ViewModels;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(string id,
        string street,
        string city,
        string state,
        string postalCode,
        string country,
        string emailAddress,
        string fullName,
        string passwordValue,
        string role,
        bool isDeleted,
        DateTime createdAt,
        DateTime? updatedAt,
        List<TransactionViewModel> transactions,
        List<FinancialGoalViewModel> financialGoals)
    {
        Id = id;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        EmailAddress = emailAddress;
        FullName = fullName;
        PasswordValue = passwordValue;
        Role = role;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Transactions = transactions;
        FinancialGoals = financialGoals;
    }

    public string Id { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public string EmailAddress { get; private set; }
    public string FullName { get; private set; }
    public string PasswordValue { get; private set; }
    public string Role { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<TransactionViewModel> Transactions { get; private set; }
    public List<FinancialGoalViewModel>  FinancialGoals { get; private set; }
}
