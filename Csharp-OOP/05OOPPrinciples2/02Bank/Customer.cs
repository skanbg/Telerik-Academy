using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank
{
    public class Customer
    {
        public CustomersType CustomerType { get; set; }
        public string CustomerName { get; set; }
        public Customer(string name, CustomersType type)
        {
            this.CustomerName = name;
            this.CustomerType = type;
        }
    }
}
