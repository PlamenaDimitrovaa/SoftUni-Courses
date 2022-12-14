namespace PrintEvenNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Thread thread = new Thread(() => PrintEvenNumbers(a, b));
            thread.Start();
            thread.Join();
            Console.WriteLine("Thread Finished Work");
        }

        static void PrintEvenNumbers(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}