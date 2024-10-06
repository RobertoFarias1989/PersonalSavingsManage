﻿namespace PersonalSavingsManage.Application.User.ViewModels;

public class UserViewModel
{
    public UserViewModel(string id,
        string street,
        string city,
        string state,
        string postalCode,
        string country, string emailAddress, string fullName, string passwordValue, string role)
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
}
