using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public interface IDepositable
    {
        void Deposit(decimal sum);
    }
}
