using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CompareHumans
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        { }
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : this(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        public decimal MoneyPerHour()
        {
            return Math.Round((this.WeekSalary / 7) / this.WorkHoursPerDay, 2);
        }
    }
}
