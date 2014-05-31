using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public class DepositAcc : Account, IWithrawable, IDepositable
    {
        public DepositAcc(Customer accCustomer, decimal accBalance, decimal accInterest)
            : base(accCustomer, accBalance, accInterest, AccountType.Deposit)
        {

        }

        public void Withdraw(decimal sum)
        {
            this.Balance -= sum;
        }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance >= 1000)
            {
                return months * this.Interest;
            }
            return 0;
        }
    }
}
