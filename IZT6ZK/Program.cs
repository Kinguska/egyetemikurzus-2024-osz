using System.Drawing;
using System.Reflection.Metadata;

using IZT6ZK;
using IZT6ZK.Commands;

using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        

        using var db = new MyDbContext();

        db.Database.Migrate();

        // Note: This sample requires the database to be created before running.

        Console.WriteLine("Inserting a new blog");
        db.Add(new QuestionEntity() { Question="Which color cat is the craziest?", Answer1="black", Answer2="orange", Answer3="grey", Answer4="white", CorrectAnswer="orange" });
        db.SaveChanges();

        Console.WriteLine("Querying for a blog");
        var question = db.Questions
            .OrderBy(b => b.QuestionId)
            .First();
        Console.WriteLine(question);



        Console.WriteLine("Hello dear Visitor in our Quiz app!\n");
        Console.WriteLine("You can make a question or check your knowledge\n");

       
        HelpCommand helpCommand = new HelpCommand();
        helpCommand.execute();


        Console.WriteLine("\n\nHave fun!\n");



        while (true)
        {
            string input = Console.ReadLine();
            if (input != null)
            {
                
                try
                {
                    CommandsDict.commandsDict.First(x => x.Key == input).Value.execute();
                }
                catch 
                {
                    Console.WriteLine("No such command exists! Try again");
                }
                
            }
        }


    }


}