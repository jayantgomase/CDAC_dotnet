using System.Collections.Generic;

namespace StudentList2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num of Batches: ");
            int batch = Convert.ToInt32(Console.ReadLine());
            var arr = new List<List<Student>>();

            for (int i = 0; i < batch; i++)
            {
                Console.Write("Enter num of Students for Batch " + (i + 1) + ": ");
                int std = Convert.ToInt32(Console.ReadLine());
                List<Student> studentList = new List<Student>();
                for (int j = 0; j < std; j++)
                {
                    Console.Write("Enter marks: ");
                    int marks = Convert.ToInt32(Console.ReadLine());
                    studentList.Add(new Student((i + 1) * 10 + (j + 1), marks, i + 1));
                }
                arr.Add(studentList);
            }

            Student.Display(arr);
        }
    }

    internal class Student
    {
        public int Id { get; }
        public int Marks { get; set; }
        public int BatchNo { get; set; }

        public Student(int id, int marks, int batchNo = 0)
        {
            Id = id;
            Marks = marks;
            BatchNo = batchNo;
        }

        public override string ToString()
        {
            return "StudentId: " + Id + " Marks: " + Marks + " Batch: " + BatchNo;
        }

        public static void Display(List<List<Student>> arrStudents)
        {
            foreach (List<Student> stdList in arrStudents)
            {
                foreach (Student student in stdList)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }

    }