using System;
using System.Text.RegularExpressions;

namespace StregsystemSolution
{
    public delegate void OnUpdateBalance(User user);
    public class User : IComparable<User>
    {
        private int UserID;
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _email;
        private decimal _balance;

        public User(int userID, string firstName, string lastName, string username, string email, decimal balance)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Balance = balance;
        }
        
        public string FirstName
        {
            get => _firstName;
            private set => _firstName = value ?? throw new Exception("Value is null");
        }
        
        public string LastName
        {
            get => _lastName;
            private set => _lastName = value ?? throw new Exception("Value is null");
        }

        public string Username
        {
            get => _username;
            set
            {
                Regex validateUsername = new Regex(@"^([a-z0-9_]+)$");
                if (validateUsername.IsMatch(value))
                {
                    _username = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Username");
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                Regex validateEmail = new Regex(@"^([A-Za-z0-9_\.\-]+)@[^\-\.]([A-Za-z0-9_\.\-]+)\.([A-Za-z0-9_\.\-]+)[^\-\.]$");
                if (validateEmail.IsMatch(value))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Email");
                }
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                UpdateBalance?.Invoke(this);
            }
        }
        public event OnUpdateBalance UpdateBalance;
        
        public override string ToString()
        {
            return FirstName + " " + LastName + " (" + Email + ")";
        }
        
        public override bool Equals(Object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
        
        public int CompareTo(User comparedUser)
        {
            if (UserID < comparedUser.UserID)
            {
                return -1;
            }
            return UserID > comparedUser.UserID ? 1 : 0;
        }
    }
}