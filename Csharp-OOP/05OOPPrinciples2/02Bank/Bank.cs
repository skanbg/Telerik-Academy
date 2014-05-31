using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public class Bank
    {
        public List<Account> Accounts { get; private set; }
        public string BankName { get; private set; }

        public Bank(string name)
        {
            this.BankName = name;
        }

        public void AddAccount(Account newAccount)
        {
            this.Accounts.Add(newAccount);
        }

        public void RemoveAccount(int index)
        {
            this.Accounts.RemoveAt(index);
        }

        public Account this[int index]
        {
            get
            {
                return Accounts[index];
            }
        }
    }
}
