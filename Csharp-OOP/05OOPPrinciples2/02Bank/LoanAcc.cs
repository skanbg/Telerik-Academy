using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public class LoanAcc : Account, IDepositable
    {
        public LoanAcc(Customer accCustomer, decimal accBalance, decimal accInterest)
            : base(accCustomer, accBalance, accInterest, AccountType.Loan)
        {

        }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }


        public override decimal CalculateInterest(int months)
        {
            if (this.AccountCustomer.CustomerType == CustomersType.companies && months > 2)
            {
                return months * this.Interest;
            }
            else if (this.AccountCustomer.CustomerType == CustomersType.companies && months > 3)
            {
                return months * this.Interest;
            }
            return 0;
        }
    }
}
