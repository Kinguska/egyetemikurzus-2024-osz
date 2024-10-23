using IZT6ZK;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello dear Visitor in our Quiz app!\n");
        Console.WriteLine("You can make a question or check your knowledge\n");

        Commands commands = new Commands();

        Console.Write("possible commands: ");

        foreach (var item in Commands.commandsDict.Keys)
        {
            Console.Write($"{item} | ");
        }

        Console.WriteLine("\n\nHave fun!\n");

        while (true)
        {
            string input = Console.ReadLine();
            if (input != null)
            {
                try
                {
                    Commands.commandsDict[input].Invoke();
                }
                catch 
                {
                    Console.WriteLine("No such command exists! Try again");
                }
                
            }
        }


    }


}