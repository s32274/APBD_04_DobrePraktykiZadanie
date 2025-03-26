using System;

namespace LegacyApp
{
    public class User
    {
        public int Id { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string Address { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        public string Type { get; set; }


        public User(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            DateOfBirth = dateOfBirth;
            
        }

        public bool HasLowCreditLimit()
        {
            return HasCreditLimit && CreditLimit < 500;
        }
    }
}