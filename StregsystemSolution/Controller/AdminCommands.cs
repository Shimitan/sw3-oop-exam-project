using System;
using Core;
using Core.Transactions;
using UserInterface;

namespace Controller
{
    public class AdminCommands
    {
        private IStregsystemUI _stregsystemUI;
        private IStregsystem _stregsystem;

        public AdminCommands(IStregsystemUI stregsystemUI, IStregsystem stregsystem)
        {
            _stregsystemUI = stregsystemUI;
            _stregsystem = stregsystem;
        }

        public void Quit(string[] args)
        {
            _stregsystemUI.Close();
        }

        public void ActivateProduct(string[] args)
        {
            _stregsystem.GetProductByID(Convert.ToInt32(args[1])).Activate();
        }

        public void DeactivateProduct(string[] args)
        {
            _stregsystem.GetProductByID(Convert.ToInt32(args[1])).Deactivate();
        }

        public void CreditOnProduct(string[] args)
        {
            _stregsystem.GetProductByID(Convert.ToInt32(args[1])).CreditOn();
        }

        public void CreditOffProduct(string[] args)
        {
            _stregsystem.GetProductByID(Convert.ToInt32(args[1])).CreditOff();
        }

        public void AddCredits(string[] args)
        {
            InsertCashTransaction insertCashTransaction = _stregsystem.AddCreditsToAccount(_stregsystem.GetUserByUsername(args[1]), Convert.ToInt32(args[2]));
            insertCashTransaction.Execute();
        }
    }
}