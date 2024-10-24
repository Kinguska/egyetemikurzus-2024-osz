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
            TopicEntity topic = new TopicEntity();
            topic.TopicName = "cats";

            QuestionEntity question1 = new QuestionEntity("Which color cat is the craziest?", "black", "orange", "grey", "white", "orange");
            question1.Topic = topic;

            Console.WriteLine("Write 'quit' if you want to quit this question\n");
            Console.WriteLine(question1.ToString());

            while (true)
            {
                var inputAnswer = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputAnswer))
                {
                    inputAnswer = inputAnswer.Trim();

                    if (inputAnswer.Equals(question1.CorrectAnswer))
                    {
                        Console.WriteLine("Correct answer!\n");
                        break;
                    }
                    if (inputAnswer == "quit")
                    {
                        Console.WriteLine("You quit \n");
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
