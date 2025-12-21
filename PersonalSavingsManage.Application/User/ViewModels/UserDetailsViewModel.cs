using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.User.ViewModels;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(int id,
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
        List<TransactionDetailsViewModel> transactions,
        List<GoalDetailsViewModel> goals)
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
        Goals = goals;
    }

    public int Id { get; private set; }
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
    public List<TransactionDetailsViewModel> Transactions { get; private set; }
    public List<GoalDetailsViewModel>  Goals { get; private set; }

    public static UserDetailsViewModel FromEntity(Core.Entities.User entity)
    {
        var transactions = entity.Transactions?
             .Select(TransactionDetailsViewModel.FromEntity)
             .ToList() ?? new List<TransactionDetailsViewModel>();

        var goals = entity.Goals?
            .Select(GoalDetailsViewModel.FromEntity)
            .ToList() ?? new List<GoalDetailsViewModel>();

        return new UserDetailsViewModel(entity.Id, entity.Address.Street, entity.Address.City, entity.Address.State,
            entity.Address.PostalCode, entity.Address.Country, entity.Email.EmailAddress, entity.Name.FullName,
            entity.Password.PasswordValue, entity.Role.ToString(), entity.IsDeleted, entity.CreatedAt,
            entity.UpdatedAt, transactions, goals);
    }
}
