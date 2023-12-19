namespace Inheritance_Assign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employees...");
            GeneralManager o = new GeneralManager("jay", 150000);
            Console.WriteLine(o.EmpNo);
            Console.WriteLine(o.Name);
            Console.WriteLine(o.Basic);
            Console.WriteLine(o.DeptNo);
            Console.WriteLine(o.Designation);
            Console.WriteLine(o.Perks);
        }
    }

    public abstract class Employee
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

        protected string name;
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
        protected decimal basic;
        public abstract decimal Basic
        {
            get;set;
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

        public Employee(string name = "default", decimal basic = 0, short deptno = 1)
        {
            this.EmpNo = ++empNoGenerator;
            this.Name = name;
            this.DeptNo = deptno;
        }



        public virtual decimal GetNetSalary()
        {
            return basic + basic * 0.1m + basic * 0.08m;
        }
    }

    public class Manager : Employee
    {
        public override decimal Basic
        {
            set
            {
                if (value < 10000)
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

        private string designation;
        public string Designation
        {
            set 
            {
                if (value == "")
                {
                    Console.WriteLine("Designation can't be blank!!");
                    return;
                }
                else
                {
                    designation = value;
                }
            }
            get { return designation; }
        }

        

        public Manager(string name = "default", decimal basic = 10000, short deptno = 1, string designation = "default designation") : base(name, deptno)
        {
            this.Basic = basic;
            this.Designation = designation;
        }
    }

    public class GeneralManager : Manager
    {
        private string perks;
        public new string Perks
        {
            set { perks = value; }
            get { return perks; }
        }

        public GeneralManager(string name = "default", decimal basic = 0, short deptno = 1, string designation = "default designation", string perks = "default perk") : base(name, basic, deptno, designation)
        {
            this.Perks = perks;
        }
    }

    public class CEO : Employee
    {
        public override decimal Basic
        {
            set
            {
                if (value < 50000)
                {
                    Console.WriteLine("Basic must be greater than 50000");
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

        

        public CEO(string name = "default", decimal basic = 50000, short deptno = 1) : base(name, deptno)
        {
            this.Basic = basic;
        }

        public sealed override decimal GetNetSalary()
        {
            return basic + basic * 0.1m + basic * 0.08m;
        }
    }
}