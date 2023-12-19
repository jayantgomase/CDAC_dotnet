using Microsoft.Data.SqlClient;
using System.Buffers.Text;
using System.Data;

namespace DBConn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee emp = new Employee(6, "Rohit", 25635, 10);
            //Employee.Insert(emp);
            //Employee.Update(emp);
            //Employee.Delete(6);

            //Employee o = Employee.GetSingleEmployee(4);
            //Console.WriteLine(o.Name);

            List<Employee> list = Employee.GetAllEmployees();
            foreach (Employee e in list)
            {
                Console.WriteLine(e.Name);
            }
            //Console.WriteLine(list.Count);
        }

        public class Employee
        {
            public int EmpNo { get; set; }
            public string Name { get; set; }
            public decimal Basic { get; set; }
            public int DeptNo { get; set; }

            public Employee() { }

            public Employee(int empno, string name, int basic, int deptno)
            {
                EmpNo = empno;
                Name = name;
                Basic = basic;
                DeptNo = deptno;
            }

            public static void Insert(Employee emp)
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                    try
                    {
                        cn.Open();
                        SqlCommand cmdInsert = new SqlCommand();
                        cmdInsert.Connection = cn;
                        cmdInsert.CommandType = CommandType.Text;
                        cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                        cmdInsert.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                        cmdInsert.Parameters.AddWithValue("@Name", emp.Name);
                        cmdInsert.Parameters.AddWithValue("@Basic", emp.Basic);
                        cmdInsert.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                        cmdInsert.ExecuteNonQuery();
                        Console.WriteLine("Insert success");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            public static void Update(Employee emp)
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                    try
                    {
                        cn.Open();
                        SqlCommand cmdUpdate = new SqlCommand();
                        cmdUpdate.Connection = cn;
                        cmdUpdate.CommandType = CommandType.Text;
                        cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";

                        cmdUpdate.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                        cmdUpdate.Parameters.AddWithValue("@Name", emp.Name);
                        cmdUpdate.Parameters.AddWithValue("@Basic", emp.Basic);
                        cmdUpdate.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                        cmdUpdate.ExecuteNonQuery();
                        Console.WriteLine("Update success");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            public static void Delete(int EmpNo)
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                    try
                    {
                        cn.Open();
                        SqlCommand cmdDelete = new SqlCommand();
                        cmdDelete.Connection = cn;
                        cmdDelete.CommandType = CommandType.Text;
                        cmdDelete.CommandText = "delete from Employees where EmpNo = @EmpNo";
                        cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);

                        cmdDelete.ExecuteNonQuery();
                        Console.WriteLine("Delete success");
                        

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            public static Employee GetSingleEmployee(int EmpNo)
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    Employee emp = new Employee();
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                    try
                    {
                        cn.Open();
                        SqlCommand cmdDelete = new SqlCommand();
                        cmdDelete.Connection = cn;
                        cmdDelete.CommandType = CommandType.Text;
                        cmdDelete.CommandText = "select * from Employees where EmpNo = @EmpNo";
                        cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);
                        SqlDataReader dr = cmdDelete.ExecuteReader();
                        if (dr.Read())
                        {
                            emp.EmpNo = dr.GetInt32("EmpNo");
                            emp.Name = dr.GetString("Name");
                            emp.Basic = dr.GetDecimal("Basic");
                            emp.DeptNo = dr.GetInt32("DeptNo");
                        } else
                        {
                            emp = null;
                        }
                        Console.WriteLine("success");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return emp;
                }
            }

            public static List<Employee> GetAllEmployees()
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    List<Employee> empList = new List<Employee>();
                    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                    try
                    {
                        cn.Open();
                        SqlCommand cmdAll = new SqlCommand();
                        cmdAll.Connection = cn;
                        cmdAll.CommandType = CommandType.Text;
                        cmdAll.CommandText = "select * from Employees";
                        
                        SqlDataReader dr = cmdAll.ExecuteReader();
                        while (dr.Read())
                        {
                            empList.Add(new Employee { EmpNo = dr.GetInt32("EmpNo"), Name = dr.GetString("Name"), Basic = dr.GetDecimal("Basic"), DeptNo = dr.GetInt32("DeptNo") });
                        }                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return empList;
                }
            }
        }
    }
}
