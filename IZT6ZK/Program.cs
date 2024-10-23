using IZT6ZK;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello dear Visitor in our Quiz app!\n");
        Console.WriteLine("You can make a question or check your knowledge\n");


       

        Console.Write("possible commands: ");

        foreach (var item in CommandsDict.commandsDict.Keys)
        {
            Console.Write($"{item} | ");
        }

        Console.WriteLine("\n\nHave fun!\n");



        while (true)
        {
            string input = Console.ReadLine();
            if (input != null)
            {
                foreach (var item in CommandsDict.commandsDict)
                {
                    if (input == item.Key)
                    {
                        item.Value.execute();
                    }
                }



                try
                {
                    
                    
                }
                catch 
                {
                    Console.WriteLine("No such command exists! Try again");
                }
                
            }
        }


    }


}