using System.Drawing;

using IZT6ZK;
using IZT6ZK.Commands;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello dear Visitor in our Quiz app!\n");
        Console.WriteLine("You can make a question or check your knowledge\n");

       
        HelpCommand helpCommand = new HelpCommand();
        helpCommand.execute();


        Console.WriteLine("\n\nHave fun!\n");



        Topics topic = new Topics();
        topic.TopicName = "cats";

        Questions question = new Questions();
        question.Question = "Which color cat is the craziest?";
        question.Answer1 = "black";
        question.Answer2 = "orange";
        question.Answer3 = "grey";
        question.Answer4 = "white";
        question.CorrectAnswer = "orange";
        question.TopicOfQuestion = topic;



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