namespace ListToArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of List: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            List<int> ints = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter element to List: ");
                ints.Add(Convert.ToInt32(Console.ReadLine()));
            }
            ints.Sort();
            int j = 0;
            foreach (int i in ints)
            {
                Console.Write(i + " ");
                arr[j++] = i;
            }
            Console.WriteLine();
            
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }
    }
}