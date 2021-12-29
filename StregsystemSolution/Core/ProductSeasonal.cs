using System;

namespace Core
{
    public class ProductSeasonal : Product
    {
        public ProductSeasonal(int productID, string productName, decimal price, bool active, 
            DateTime seasonStartDate, DateTime seasonEndDate) : base(productID, productName, price, active)
        {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        private DateTime SeasonStartDate;
        private DateTime SeasonEndDate;
    }
}