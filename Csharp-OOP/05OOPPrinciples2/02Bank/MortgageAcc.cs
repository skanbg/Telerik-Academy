using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public class MortgageAcc : Account, IDepositable
    {
        public MortgageAcc(Customer accCustomer, decimal accBalance, decimal accInterest)
            : base(accCustomer, accBalance, accInterest, AccountType.Mortgage)
        {

        }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal CalculateInterest(int months)
        {
            //First calculating the interest in promo period
            decimal buffer = 0;
            int afterPromo = months;
            if (this.AccountCustomer.CustomerType == CustomersType.companies)
            {
                int[] promoResult = returnMonthsAfterPromo(months, 12);
                buffer += promoResult[0] * (this.Interest / 2);
                afterPromo = promoResult[1];
            }
            else if (this.AccountCustomer.CustomerType == CustomersType.individuals)
            {
                int[] promoResult = returnMonthsAfterPromo(months, 6);
                buffer = 0;
                afterPromo = promoResult[1];
            }
            //than whats left is calculated here and summed with buffer(promo sum)
            return (this.Interest * afterPromo) + buffer;
        }

        private int[] returnMonthsAfterPromo(int months, int promoPeriod)
        {
            if (months % promoPeriod >= 1)
            {
                return new int[] { promoPeriod, months - promoPeriod };
            }
            else
            {
                return new int[] { months, 0 };
            }
        }
    }
}
