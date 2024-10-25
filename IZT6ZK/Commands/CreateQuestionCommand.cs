using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IZT6ZK.Db;

namespace IZT6ZK.Commands
{
    internal class CreateQuestionCommand : ICommands
    {
        public void execute()
        {
            string? inputQuestion;
            string? inputAnswer1;
            string? inputAnswer2;
            string? inputAnswer3;
            string? inputAnswer4;
            string? inputCorrectAnswer;


            while (true)
            {
                Console.WriteLine("\nWrite 'quit' if you want to quit\n");

                Console.WriteLine("Write your question: ");
                inputQuestion = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputQuestion))
                {
                    inputQuestion = inputQuestion.Trim();

                    if (inputQuestion == "quit")
                    {
                        Console.WriteLine("You quit \n");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }
            while (true)
            {
                Console.WriteLine("\nWrite 'quit' if you want to quit\n");

                Console.WriteLine("Write the first answer: ");
                inputAnswer1 = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputAnswer1))
                {
                    inputAnswer1 = inputAnswer1.Trim();

                    if (inputAnswer1 == "quit")
                    {
                        Console.WriteLine("You quit \n");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }
            while (true)
            {
                Console.WriteLine("\nWrite 'quit' if you want to quit\n");

                Console.WriteLine("Write the second answer: ");
                inputAnswer2 = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputAnswer2))
                {
                    inputAnswer2 = inputAnswer2.Trim();

                    if (inputAnswer2 == "quit")
                    {
                        Console.WriteLine("You quit \n");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }
            while (true)
            {
                Console.WriteLine("\nWrite 'quit' if you want to quit\n");

                Console.WriteLine("Write the third answer: ");
                inputAnswer3 = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputAnswer3))
                {
                    inputAnswer3 = inputAnswer3.Trim();

                    if (inputAnswer3 == "quit")
                    {
                        Console.WriteLine("You quit \n");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }
            while (true)
            {
                Console.WriteLine("\nWrite 'quit' if you want to quit\n");

                Console.WriteLine("Write the fourth answer: ");
                inputAnswer4 = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputAnswer4))
                {
                    inputAnswer4 = inputAnswer4.Trim();

                    if (inputAnswer4 == "quit")
                    {
                        Console.WriteLine("You quit \n");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }
            while (true)
            {
                Console.WriteLine("\nWrite 'quit' if you want to quit\n");

                Console.WriteLine("Write the correct answer: ");
                inputCorrectAnswer = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputCorrectAnswer))
                {
                    inputCorrectAnswer = inputCorrectAnswer.Trim();

                    if (inputCorrectAnswer == "quit")
                    {
                        Console.WriteLine("You quit \n");
                        break;
                    }
                    if (inputCorrectAnswer != inputAnswer1 && inputCorrectAnswer != inputAnswer2 && inputCorrectAnswer != inputAnswer3 && inputCorrectAnswer != inputAnswer4)
                    {
                        Console.WriteLine("The correct answer must match one of the given answers!");
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Write something please!");
                }
            }
            Console.WriteLine(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer);

        }
    }
}
