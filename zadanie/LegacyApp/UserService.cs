using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            User user = new User(firstName, lastName, firstName, lastName, email, dateOfBirth);

            if (user.HasIncorrectNames()) return false;

            if (user.HasIncorrectEmail()) return false;

            

            if (user.GetAge() < 21) return false;
            
            user.ClassifyCreditLimit();

            if (user.HasLowCreditLimit()) return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
