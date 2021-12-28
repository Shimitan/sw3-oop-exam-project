using System;

namespace StregsystemSolution
{
    public class Product
    {
        private string _productName;
        private decimal _price;
        private bool _active;
        private bool _canBeBoughtOnCredit;
        
        public Product(int productID, string productName, decimal price, bool active)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
            Active = active;
        }
        
        public int ProductID; // Type 'int' ensures value is never under 1
        
        public string ProductName
        {
            get => _productName;
            set => _productName = value ?? throw new Exception("Value is null");
        }
        public decimal Price { get; }
        
        public bool Active { get; private set; }
        public void Activate()
        {
            Active = true;
        }
        public void Deactivate()
        {
            Active = false;
        }

        public bool CanBeBoughtOnCredit { get; private set; }
        public void CreditOn()
        {
            CanBeBoughtOnCredit = true;
        }
        public void CreditOff()
        {
            CanBeBoughtOnCredit = false;
        }
        
        public override string ToString()
        {
            return ProductID + " " + ProductName + " " + Price;
        }
    }
}