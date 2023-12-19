using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arrays_Assign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. CDAC YCP has certain number of batches.each batch has certain number of students
            // accept number of batches. for each batch accept number of students.
            // create an array to store mark for each student (1 student has only 1 subject mark)
            //accept the marks.
            //display the marks.

            Console.WriteLine("----------CDAC----------\n");

            Console.Write("Enter the no. of batches : ");
            int batch = Convert.ToInt32(Console.ReadLine());

            Batch[] batchArr = new Batch[batch];
            
            for (int i = 0; i < batchArr.Length; i++) 
            {
                batchArr[i] = new Batch();
            }
            Console.WriteLine();

            for (int i = 0; i < batchArr.Length; i++)
            {
                Console.Write($"Enter the no. of students for batch {i + 1} : ");
                int students = Convert.ToInt32(Console.ReadLine());
                batchArr[i].StudentsArr = new int[students];
            }
            Console.WriteLine();

            for (int i = 0; i < batchArr.Length; i++)
            {
                Console.WriteLine($"For batch {i + 1} : ");
                for (int j = 0; j < batchArr[i].StudentsArr.Length; j++)
                {
                    Console.Write($"Enter the marks student {j + 1} : ");
                    batchArr[i].StudentsArr[j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }

            for (int i = 0; i < batchArr.Length; i++)
            {
                Console.WriteLine($"For batch {i + 1} : ");
                for (int j = 0; j < batchArr[i].StudentsArr.Length; j++)
                {
                    Console.WriteLine($"Student {j + 1} marks = {batchArr[i].StudentsArr[j]}");
                }
                Console.WriteLine();
            }
        }

        public class Batch
        {
            private int[] studentArr;
            public int[] StudentsArr
            {
                set { studentArr = value; }
                get { return studentArr; }
            }
            
            private int marks;
            public int Marks
            {
                get { return marks; }
                set { marks = value; }
            }

            public Batch() { }
        }
    }
}
