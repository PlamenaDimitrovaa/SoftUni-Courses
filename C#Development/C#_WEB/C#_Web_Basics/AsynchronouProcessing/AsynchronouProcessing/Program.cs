namespace AsynchronouProcessing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintNumbersInRange(0, 100);

            Task task = Task.Run(() => PrintNumbersInRange(100, 200));
            Task newTask = Task.Run(() => PrintNumbersInRange(500, 600));

            Console.WriteLine("Done");

            task.Wait();
            newTask.Wait();
        }

        static void PrintNumbersInRange(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                Console.WriteLine($"{i},");
            }
        }
    }
}