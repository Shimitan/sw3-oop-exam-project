using System;

namespace Core.Exceptions
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