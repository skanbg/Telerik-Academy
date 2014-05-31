using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public abstract class Account
    {
        public Customer AccountCustomer { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public AccountType AccType { get; private set; }
        public Account(Customer accCustomer, decimal accBalance, decimal accInterest, AccountType type)
        {
            this.AccountCustomer = accCustomer;
            this.Balance = accBalance;
            this.Interest = accInterest;
            this.AccType = type;
        }
        public abstract decimal CalculateInterest(int months);
    }
}
