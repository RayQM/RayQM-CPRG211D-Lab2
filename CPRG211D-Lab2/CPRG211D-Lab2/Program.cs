using CPRG211D_Lab2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211D_Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            string path = "employees.txt";

            string[] lines = File.ReadAllLines(@path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                string firstDight = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstDight);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {

                    string salary = cells[7];


                    double salaryDouble = double.Parse(salary);


                    Salaried salaried = new Salaried(id, name, address, salaryDouble);


                    employees.Add(salaried);
                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {

                    string rate = cells[7];
                    string hours = cells[8];


                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);


                    Wages wages = new Wages(id, name, address, rateDouble, hoursDouble);


                    employees.Add(wages);
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {

                    string rate = cells[7];
                    string hours = cells[8];


                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);


                    PartTime partTime = new PartTime(id, name, address, rateDouble, hoursDouble);


                    employees.Add(partTime);
                }
            }
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                double weeklypay = employee.CalcWeeklyPay();

                weeklyPaySum += weeklypay;

            }
            double averageWeeklypay = weeklyPaySum / employees.Count;

            Console.WriteLine("Avarage weekly pay" + averageWeeklypay);

            Wages hightPaidWaged = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    Wages wages = (Wages)employee;
                    if (hightPaidWaged == null || wages.CalcWeeklyPay() > hightPaidWaged.CalcWeeklyPay())
                    {
                        hightPaidWaged = wages;
                    }
                }
            }

            Console.WriteLine("Employee " + hightPaidWaged.Name + "is highest paid " + hightPaidWaged.CalcWeeklyPay());

            Salaried lowestPaidWaged = null;
            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    Salaried salaried = (Salaried)employee;
                    if (lowestPaidWaged == null || salaried.CalcWeeklyPay() < lowestPaidWaged.CalcWeeklyPay())
                    {
                        lowestPaidWaged = salaried;
                    }

                }


            }
            Console.WriteLine("Employee " + lowestPaidWaged.Name + " is lowest paid " + lowestPaidWaged.CalcWeeklyPay());

            
            double salariedPercentage = 0;
            double salaroedEmployeeCount = 0;
            foreach (Employee employee in employees)
            {

                if (employee is Salaried)
                {
                    salaroedEmployeeCount += 1;
                }
                salariedPercentage = (salaroedEmployeeCount / employees.Count)*100;

            }

            Console.WriteLine("Salaried: "+ salaroedEmployeeCount+ "/"+ employees.Count +"("+Math.Round(salariedPercentage, 2)+"%)") ;
            
            double wagesPercentage = 0;
            double wagesEmployeeCount = 0;
            foreach (Employee employee in employees)
            {

                if (employee is Wages)
                {
                    wagesEmployeeCount += 1;
                }
                wagesPercentage = (wagesEmployeeCount / employees.Count) * 100;

            }

            Console.WriteLine("Waged: " + wagesEmployeeCount + "/" + employees.Count + "(" + Math.Round(wagesPercentage, 2) + "%)");

            double parttimePercentage = 0;
            double parttimeEmployeeCount = 0;
            foreach (Employee employee in employees)
            {

                if (employee is PartTime)
                {
                    parttimeEmployeeCount += 1;
                }
                parttimePercentage = (parttimeEmployeeCount / employees.Count) * 100;

            }

            Console.WriteLine("Part time: " + parttimeEmployeeCount + "/" + employees.Count + "(" + Math.Round(parttimePercentage, 2) + "%)");
        }
    }
}