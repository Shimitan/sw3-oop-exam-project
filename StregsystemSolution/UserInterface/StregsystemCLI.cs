using System;
using Core;
using Core.Transactions;

namespace UserInterface
{
    public class StregsystemCLI : IStregsystemUI
    {
        private IStregsystem _stregsystem;
        private bool _running;
        
        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }
        
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User " + username + " not found!");
        }

        public void DisplayProductNotFound(int product)
        {
            Console.WriteLine("Product " + product + " not found!");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine("User information:" +
                              "\nUsername: " + user.Username +
                              "\nBalance: " + user.Balance +
                              "\nFull name: " + user.FirstName + " " + user.LastName +
                              "\nEmail: " + user.Email);
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine("Command Error: " + command + ", has too many arguments");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine("Admin command: " + "'" + adminCommand + "'" + " is not found!");
        }
        
        // Method overload 1/2
        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.User + " bought " + transaction.Product.ProductName + " for " + transaction.Amount);
        }

        // Method overload 2/2
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine(transaction.User + " bought " + count + " of " + transaction.Product.ProductName + " for " + transaction.Amount);
        }
        
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine(user.Username + " has insufficient balance to buy " + product.ProductName + " for " + product.Price);
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        public void Start()
        {
            _running = true;
            
            // UI print
            Console.WriteLine("List of active products (ID Product Price):\n");
            foreach (Product product in _stregsystem.ActiveProducts)
            {
                Console.WriteLine(product.ProductID + " " + product.ProductName + " " + product.Price);
            }
            Console.WriteLine("To buy a product type your username followed by the ID of wanted product (space seperated).");
            
            // UI input
            while (_running)
            {
                
                string command = Console.ReadLine();
                Console.Clear();
                CommandEntered?.Invoke(command);
            }
        }
        
        public void Close()
        {
            throw new NotImplementedException();
        }
        
        public event StregsystemEvent CommandEntered;
    }
}