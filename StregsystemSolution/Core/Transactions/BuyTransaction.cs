using System;
using Core.Exceptions;

namespace Core.Transactions
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(int transactionID, User user, DateTime date, Product product, int amount) : base(transactionID, user, date, product.Price)
        {
            if (!product.Active)
            {
                throw new ProductNotActiveException(product);
            }
            Product = product;
            _amount = amount;
        }
        
        public Product Product { get; }
        private readonly int _amount;

        public void Execute()
        {
            if (Product.CanBeBoughtOnCredit || User.Balance - Product.Price * _amount >= 0)
            {
                User.Balance -= Product.Price * _amount ;
            }
            else
            {
                throw new InsufficientCreditsException(User, Product);
            }
        }
    }
}