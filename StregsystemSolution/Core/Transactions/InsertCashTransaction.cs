using System;

namespace Core.Transactions
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(int transactionID, User user, DateTime date, decimal amount) : base(transactionID, user, date, amount)
        {
            User = user;
        }

        public void Execute()
        {
            User.Balance += Amount;
        }
    }
}