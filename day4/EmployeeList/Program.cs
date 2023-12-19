namespace EmployeeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number of Employees: ");
            int num = Convert.ToInt32(Console.ReadLine());
            List<Employee> arrEmps = new List<Employee>(num);

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter emp details: ");
                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();
                Console.Write("Enter Salary: ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                arrEmps.Add(new Employee(name, salary));
            }

            Employee.Display(arrEmps);

            Console.WriteLine(Employee.getHighestSalEmp(arrEmps));
            Console.Write("Enter id: ");
            Console.WriteLine(Employee.findEmployee(Convert.ToInt32(Console.ReadLine()), arrEmps));

        }
    }

    internal class Employee
    {
        public static int Increament = 0;
        public int EmpNo { get; }
        private string name = "Undefined";
        public string Name { get { return name; } set { if (value != "") name = value; } }
        public decimal Salary { get; set; }
        public short DeptNo { get; set; }

        public Employee(string name = "", decimal salary = 2000, short dept = 1)
        {
            EmpNo = ++Increament;
            Name = name;
            Salary = salary;
            DeptNo = dept;
        }

        public override string ToString()
        {
            return "EmpNo: " + EmpNo + " Name: " + Name + " Salary: " + Salary;
        }

        public static Employee getHighestSalEmp(List<Employee> arrEmps)
        {
            decimal max = 0;
            Employee emp = null;
            foreach (Employee item in arrEmps)
            {
                if (item.Salary > max)
                {
                    emp = item;
                    max = item.Salary;
                }
            }
            Console.Write("Highest Salaried Employee: ");
            return emp;
        }

        public static string findEmployee(int id, List<Employee> arrEmps)
        {
            foreach (Employee item in arrEmps)
            {
                if (item.EmpNo == id)
                {
                    return item.ToString();
                }
            }
            return "No Employee found with such Id ..";
        }

        public static void Display(List<Employee> arrEmps)
        {
            foreach (Employee item in arrEmps)
            {
                Console.WriteLine(item);
            }
        }
    }
}