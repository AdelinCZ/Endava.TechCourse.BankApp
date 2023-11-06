namespace ex1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            {
                Guid newGuid = Guid.NewGuid();
                string firstGuid = newGuid.ToString();

                var boolish = Guid.TryParse(firstGuid, out var anotherGuid);

                if (boolish)
                {
                    Console.WriteLine("Converted {0} to a Guid", anotherGuid);
                }
                else
                    Console.WriteLine("Unable to convert {0} to a Guid", anotherGuid);
            }
        }
    }
}