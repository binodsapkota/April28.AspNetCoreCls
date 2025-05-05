using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals.OOP
{
    internal class BankAccount
    {
        private double balance;
        public void Deposit(double amount)
        {
            balance += amount;
        }
        public double GetBalance()
        {
            return balance;
        }
    }
}
