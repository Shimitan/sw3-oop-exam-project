using System;

namespace StregsystemSolution.Exceptions
{
    public class ProductNotActiveException : Exception
    {
        public ProductNotActiveException(Product product)
        {
            Product = product;
        }

        public Product Product;
    }
}