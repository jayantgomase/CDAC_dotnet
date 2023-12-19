using System.Transactions;

namespace Employee_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //2.Create an array of Employee class objects
        //Accept details for all Employees
        //Display the Employee with highest Salary
        //Accept EmpNo to be searched.Display all details for that employee.
            Console.WriteLine("-----------Employees----------");
            Console.Write("Enter no. of employees : ");
            Employee[] employees = new Employee[Convert.ToInt32(Console.ReadLine())];

            for (int i = 0; i < employees.Length; i++)
            {
                Console.Write($"Enter the name, basic salary and dept. no. of employee {i} : ");
                employees[i] = new Employee(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
            }
            Console.WriteLine();

            // Employee with highest salary
            decimal[] salaries = new decimal[employees.Length];
            for (int i = 0; i < salaries.Length; i++)
            {
                salaries[i] = employees[i].CalcNetSalary();
            }
            
            Console.WriteLine("Employee with highest salary\n" + employees[Array.IndexOf(salaries, salaries.Max())].ToString());
            Console.WriteLine($"Net salary : {salaries.Max()}\n");

            //searching employee
            int[] empNos = new int[employees.Length];
            for ( int i = 0; i < empNos.Length; i++)
            {
                empNos[i] = employees[i].EmpNo;
            }
            Console.Write("Enter the EmpNo. to be searched : ");
            int target = Convert.ToInt32(Console.ReadLine());
            if (target < 0 || target > employees.Length)
            {
                Console.WriteLine("invalid EmpNo!!!");
            } else
            {
                Console.WriteLine(employees[Array.IndexOf(empNos, target)].ToString());
            }
        }
    }

    public class Employee
    {
        protected int empNo;
        private static int empNoGenerator = 0;
        public int EmpNo
        {
            private set
            {
                empNo = value;
            }
            get
            {
                return empNo;
            }
        }

        protected string? name;
        public string? Name
        {
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Blank Name!!");
                    return;
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        protected decimal basic;
        public decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if(value < 10000)
                {
                    Console.WriteLine("Salary less than 10000");
                    return;
                } else if (value > 200000)
                {
                    Console.WriteLine("Salary greater than 200000");
                    return;
                } else
                {
                    basic = value;
                }
            }
        }
        protected short deptNo;
        public short DeptNo
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("DeptNo must be greater than 0");
                    return;
                }
                else
                {
                    deptNo = value;
                }
            }
            get
            {
                return deptNo;
            }
        }

        public Employee(string name = "default", decimal basic = 10000, short deptno = 1)
        {
            this.EmpNo = ++empNoGenerator;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptno;
        }

        public override string ToString()
        {
            Console.WriteLine("Employee details : ");
            return $"EmpNo : {this.EmpNo}\nName : {this.Name}\nBasic : {this.Basic}\nDept.no. : {this.DeptNo}";
        }

        public virtual decimal CalcNetSalary()
        {
            return basic + basic * 0.1m + basic * 0.08m;
        }
    }
}
