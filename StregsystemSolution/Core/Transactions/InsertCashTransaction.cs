using System;

namespace StregsystemSolution.Transactions
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