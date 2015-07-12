using CriminalSearch.Repository;
using CriminalSearch.Repository.CustomException;
using CriminalSearch.Repository.Entity;
using CriminalSearch.Repository.Repository;
using CriminalSearch.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalSearch.Security
{
    public class MembershipService
    {
        private readonly IUserRepository _userRepository;
        private readonly InputValidator _inputValidtor;

        public MembershipService(IUserRepository userRepository, InputValidator inputValidtor)
        {
            _userRepository = userRepository;
            _inputValidtor = inputValidtor;
        }

        public void CreteUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new MembershipException("Username cannot be empty.");
            else if (user.Username.Length < 4 || user.Username.Length > 8)
                throw new MembershipException("Username must be 4 to 8 charcters long.");
            else if (!_inputValidtor.IsAlphaNumeric(user.Username))
                throw new MembershipException("Username must contain only alpha-numeric characters.");
            else if (string.IsNullOrWhiteSpace(user.Email))
                throw new MembershipException("Email cannot be empty.");
            else if (!_inputValidtor.IsEmail(user.Email))
                throw new MembershipException("Invalid email.");
            else if (string.IsNullOrWhiteSpace(user.Password))
                throw new MembershipException("Password cannot be empty.");
            else if (user.Username.Length < 4 || user.Username.Length > 6)
                throw new MembershipException("Username must be 4 to 6 charcters long.");
            else if (_userRepository.GetUserByEmail(user.Email) != null)
                throw new MembershipException("Email address already exist.");
            else if (_userRepository.GetUserByUsernme(user.Username) != null)
                throw new MembershipException("Username already exist.");

            _userRepository.Insert(user);
        }

        public bool Login(string usernme, string password)
        {
            bool result = false;

            if (string.IsNullOrWhiteSpace(usernme) || string.IsNullOrWhiteSpace(password))
                throw new MembershipException("Username or password cannot be empty.");

            User user = _userRepository.GetUserByUsernme(usernme);
            if (user != null && user.Password == password)
                result = true;

            return result;
        }
    }
}
