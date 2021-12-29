using System;
using Core;
using Core.Transactions;
using Xunit;

namespace Testing
{
    public class UnitTest
    {
        [Fact]
        public void BuyTransactionTest()
        {
            // Arrange
            User sutUser = new User(20, "Mike", "Jensen", "shimi","bob@realmail.com", 2500);
            decimal sutStartBalance = sutUser.Balance;
            Product sutProduct = new Product(11111, "Chips", 700, true);
            BuyTransaction buyTransaction = new BuyTransaction(1, sutUser, DateTime.Now, sutProduct, 1);

            // Act
            buyTransaction.Execute();

            // Assert
            Assert.Equal(sutStartBalance - 1 * sutProduct.Price, sutUser.Balance);
        }
    }
}