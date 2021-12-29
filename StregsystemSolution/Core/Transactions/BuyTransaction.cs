using System;
using Core.Exceptions;

namespace Core.Transactions
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(int transactionID, User user, DateTime date, Product product, decimal productPrice) : base(transactionID, user, date, product.Price)
        {
            if (!product.Active)
            {
                throw new ProductNotActiveException(product);
            }
            Product = product;
        }
        
        public Product Product { get; }

        public void Execute()
        {
            if (Product.CanBeBoughtOnCredit || User.Balance - Product.Price >= 0)
            {
                User.Balance -= Product.Price ;
            }
            else
            {
                throw new InsufficientCreditsException(User, Product);
            }
        }
    }
}