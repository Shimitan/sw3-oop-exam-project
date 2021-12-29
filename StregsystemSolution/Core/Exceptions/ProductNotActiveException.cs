using System;

namespace Core.Exceptions
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