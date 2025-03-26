using System;

namespace LegacyApp
{
    public class User
    {
        public int Id { get; internal set; }
        private static int MaxId = 1;
        public DateTime DateOfBirth { get; internal set; }
        public string Address { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        public string Type { get; set; }


        public User(string address, String clientType, string firstName, string lastName, string email,
            DateTime dateOfBirth)
        {
            Id = MaxId;
            MaxId++;

            Address = address;
            Type = clientType;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            DateOfBirth = dateOfBirth;

        }

        public bool HasLowCreditLimit()
        {
            return HasCreditLimit && CreditLimit < 500;
        }

        public int GetAge()
        {
            var now = DateTime.Now;
            int age = now.Year - DateOfBirth.Year;
            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day)) age--;
            return age;
        }

        public bool HasIncorrectNames()
        {
            return string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName);
        }

        public bool HasIncorrectEmail()
        {
            return !EmailAddress.Contains("@") && !EmailAddress.Contains(".");
        }

        public void ClassifyCreditLimit()
        {
            if (Type == "VeryImportantClient")
            {
                HasCreditLimit = false;
            }
            else if (Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    creditLimit = creditLimit * 2;
                    CreditLimit = creditLimit;
                }
            }
            else
            {
                HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    CreditLimit = creditLimit;
                }
            }
        }
    }
}