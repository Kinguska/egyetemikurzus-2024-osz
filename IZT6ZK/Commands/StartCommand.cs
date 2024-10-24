using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands
{
    internal class StartCommand : ICommands
    {
        public void execute()
        {
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


            Console.WriteLine(question.ToString());

            while (true)
            {
                var inputAnswer = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputAnswer))
                {
                    inputAnswer = inputAnswer.Trim();

                    if (inputAnswer.Equals(question.CorrectAnswer))
                    {
                        Console.WriteLine("Correct answer!\n");
                        break;
                    }
                    if (inputAnswer == "quit")
                    {
                        break;
                    }

                    Console.WriteLine("Incorrect answer, try again!");

                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }

        }
    }
}
