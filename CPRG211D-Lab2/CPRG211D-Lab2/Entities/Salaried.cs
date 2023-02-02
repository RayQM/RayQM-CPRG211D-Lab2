using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211D_Lab2.Entities
{
    internal class Salaried:Employee
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
        }

        public Salaried(string id, string name ,string address,double salary)
        {
            this.id = id;
            this.name = name;
            this.address=address;
            this.salary = salary;

        }
        public override double CalcWeeklyPay()
        {
            return salary;
        }
    }
}
