using System;

namespace StregsystemSolution.Exceptions
{
    public class UserDoesntExistException : Exception
    {
        public UserDoesntExistException(string username)
        { 
            Username = username;
        }
        public string Username;
    }
}