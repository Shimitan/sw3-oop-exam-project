using System;

namespace Core.Exceptions
{
    public class ProductDoesntExistException : Exception
    {
        public ProductDoesntExistException(int productID)
        {
            ProductID = productID;
        }
        public int ProductID;
    }
}