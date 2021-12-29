using System;
using System.Collections.Generic;
using Core.Data;
using Core.Exceptions;
using Core.Transactions;

namespace Core
{
    public class Stregsystem : IStregsystem
    {
        private IDataReader _dataReader;
        private List<User> _userList;
        private List<Product> _productList;
        private List<Transaction> _transactionList = new(); // Target typed
        private int _transactionID;

        public Stregsystem()
        {
            _dataReader = new DataReader();
            _productList = _dataReader.GetProducts();
            _userList = _dataReader.GetUsers();
            _transactionID = 1;
            _transactionList = new List<Transaction>();
            foreach (User user in _userList)
            {
                user.UpdateBalance += CheckBalance;
            }
        }
        
        IEnumerable<Product> IStregsystem.ActiveProducts => _productList.FindAll(product => product.Active);
        
        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(_transactionID, user, DateTime.Now, amount);
            _transactionID++;
            return transaction;
        }
        
        public BuyTransaction BuyProduct(User user, Product product, int amount)
        {
            BuyTransaction transaction = new BuyTransaction(_transactionID, user, DateTime.Now, product, amount);
            _transactionID++;
            return transaction;
        }
        
        public Product GetProductByID(int productID)
        {
            return _productList.Find(product => product.ProductID == productID) ?? throw new ProductDoesntExistException(productID);
        }
        
        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> totalTransactions = _transactionList;
            List<Transaction> transactionList = new List<Transaction>();
            totalTransactions.Reverse();

            foreach (Transaction transaction in totalTransactions)
            {
                if (transaction.User.Username == user.Username)
                {
                    transactionList.Add(transaction);
                    if (transactionList.Count == count)
                    {
                        return transactionList;
                    }
                }
            }
            return transactionList;
        }
        
        public List<User> GetUsers(Func<User, bool > predicate)
        {
            List<User> users = new List<User>();
            foreach (User user in _userList)
            {
                if (predicate(user))
                {
                    users.Add(user);
                }
            }
            return users;
        }
        
        public User GetUserByUsername(string username)
        {
            return _userList.Find(user => user.Username == username) ?? throw new UserDoesntExistException(username);
        }
        
        public void AddTransaction(Transaction transaction)
        {
            _transactionList.Add(transaction);
        }

        // Method to tell the user if their balance is low
        public void CheckBalance(User user)
        {
            if (user.Balance < 1000)
            {
                UserBalanceWarning?.Invoke(user);
            }
        }
        public event UserBalanceNotification UserBalanceWarning;
    }
}