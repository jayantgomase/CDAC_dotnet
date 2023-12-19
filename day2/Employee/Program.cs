namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employees...");
            Employee e1 = new Employee();
            Employee e2 = new Employee();
            Employee e3 = new Employee();

            Console.WriteLine(e1.EmpNo);
            Console.WriteLine(e2.EmpNo);
            Console.WriteLine(e3.EmpNo);
            Console.WriteLine("");
            Console.WriteLine(e3.EmpNo);
            Console.WriteLine(e2.EmpNo);
            Console.WriteLine(e1.EmpNo);
            Console.WriteLine("");
            Employee o = new Employee("Jayant", 123456, 2);
            Console.WriteLine(o.EmpNo);
            Console.WriteLine(o.Name);
            Console.WriteLine(o.Basic);
            Console.WriteLine(o.DeptNo);
            Console.WriteLine("");

            Console.WriteLine(o.GetNetSalary());
        }
    }

    public class Employee
    {
        private int empNo;
        private static int empNoGenerator = 0;
        public int EmpNo
        {
            set 
            { 
                empNo = value;
            }
            get
            {
                return empNo;
            }
        }

        private string name;
        public string Name
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
        private decimal basic;
        public decimal Basic
        {
            set
            {
                if (10000 > value)
                {
                    Console.WriteLine("Basic must be greater than 10000");
                    return;
                }
                if (value > 200000)
                {
                    Console.WriteLine("Basic must be less than 200000");
                    return;
                }
                else
                {
                    basic = value;
                }
            }
            get
            {
                return basic;
            }
        }
        private short deptNo;
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

        public Employee()
        {
            this.EmpNo = ++empNoGenerator;
        }

        public Employee(string name)
        {
            this.EmpNo = ++empNoGenerator;
            this.Name = name;
        }

        public Employee(string name, decimal basic) 
        {
            this.EmpNo = ++empNoGenerator;
            this.Name = name;
            this.Basic = basic;
        }

        public Employee(string name, decimal basic, short deptno)
        {
            this.EmpNo = ++empNoGenerator;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptno;
        }

       

        public decimal GetNetSalary()
        {
            return Calcy.Calculate.CalcSalary(basic);
        }
    }
}