using System;
using StregsystemSolution.Exceptions;

namespace StregsystemSolution.Transactions
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
            _productPrice = productPrice;
        }
        
        public Product Product { get; }
        private readonly decimal _productPrice;

        public override void Execute()
        {
            if (Product.CanBeBoughtOnCredit || User.Balance - _productPrice >= 0)
            {
                User.Balance -= _productPrice;
            }
            else
            {
                throw new InsufficientCreditsException(User, Product);
            }
        }
    }
}