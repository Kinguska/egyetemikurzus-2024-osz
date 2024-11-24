using System.Drawing;
using System.Reflection.Metadata;

using IZT6ZK;
using IZT6ZK.Commands;
using IZT6ZK.Db;

using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        /*

        using var db = new MyDbContext();

        db.Database.Migrate();

        

        Console.WriteLine("Inserting a new blog");
        db.Add(new QuestionEntity() { Question="Which color cat is the craziest?", Answer1="black", Answer2="orange", Answer3="grey", Answer4="white", CorrectAnswer="orange" });
        db.SaveChanges();

        Console.WriteLine("Querying for a blog");
        var question = db.Questions
            .OrderBy(b => b.QuestionId)
            .First();
        Console.WriteLine(question);


        */

        using (var db = new MyDbContext())
        {
            db.Database.Migrate();
        }

        Console.WriteLine("Hello dear Visitor in our Quiz app!\n");
        Console.WriteLine("You can make a question or check your knowledge\n");

        HelpCommand helpCommand = new HelpCommand();
        helpCommand.Execute();

        Console.WriteLine("\n\nHave fun!\n");

        while (true)
        {
            string? input = Console.ReadLine();

            try
            {
                input = input.Trim();
                CommandsDict.commandsDict.First(x => x.Key == input).Value.Execute();
            }
            catch
            {
                Console.WriteLine("No such command exists! Try again");
            }
        }


    }


}