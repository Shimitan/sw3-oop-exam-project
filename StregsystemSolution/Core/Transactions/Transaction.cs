using System;

namespace Core.Transactions
{
    public abstract class Transaction : ITransaction
    {
        public Transaction(int transactionID, User user, DateTime date, decimal amount)
        {
            TransactionID = transactionID;
            User = user;
            Date = date;
            Amount = amount;
        }

        protected int TransactionID { get; }
        public User User { get; protected set; }
        public DateTime Date;
        public decimal Amount { get; }
        
        public override string ToString()
        {
            return string.Format($"ID: {TransactionID} Username: {User.Username} Amount: {Amount} Date: {Date}");
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}