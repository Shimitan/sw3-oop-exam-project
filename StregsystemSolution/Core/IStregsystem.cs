using System;
using System.Collections.Generic;
using Core.Transactions;

namespace Core
{
    public delegate void UserBalanceNotification(User user);
    
    // Interface from the exercise description
    public interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; } 
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount); 
        BuyTransaction BuyProduct(User user, Product product, decimal amount); 
        Product GetProductByID(int id); 
        IEnumerable<Transaction> GetTransactions(User user, int count); 
        List<User> GetUsers(Func<User, bool> predicate); 
        User GetUserByUsername(string username);
        public void AddTransaction(Transaction transaction);
        event UserBalanceNotification UserBalanceWarning;
    }
}