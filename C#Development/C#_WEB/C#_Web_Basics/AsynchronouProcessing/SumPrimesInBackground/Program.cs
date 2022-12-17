namespace SumPrimesInBackground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long sum = 0;

            Task.Run(() =>
            {
                for (long i = 0; i < 1000000000; i++)
                {
                    sum += 1;
                    Thread.Sleep(10);
                }
            });

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "show")
                {
                    Console.WriteLine(sum);                    
                }
                else if(command == "exit") 
                {
                    return;
                }
            }
        }
    }
}