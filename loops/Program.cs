namespace loops
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random randomGenerator = new Random();

            int randomNumber = randomGenerator.Next(1, 11);
            int hint;

            do
            {
                Console.WriteLine("ENTER A NUMBER");
                hint = Convert.ToInt32(Console.ReadLine());

                if (hint > randomNumber)
                {
                    Console.WriteLine("TOO HIGH");
                }
                else if (hint < randomNumber)
                {
                    Console.WriteLine("too low");
                }
            } while (hint != randomNumber);
            Console.WriteLine("correct");
        }
    }
}