using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK;

internal class QuestionEntity
{
    public int QuestionId { get; set; }
    public string Question {  get; set; }
    public string Answer1 {  get; set; }
    public string Answer2 { get; set; }
    public string Answer3 { get; set; }
    public string Answer4 { get; set; }
    public string CorrectAnswer { get; set; }
    public TopicEntity? Topic { get; set; }
    public int? TopicId { get; set; }

    public QuestionEntity() {}

    public QuestionEntity(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer)
    {
        Question = question;
        Answer1 = answer1;
        Answer2 = answer2;
        Answer3 = answer3;
        Answer4 = answer4;
        CorrectAnswer = correctAnswer;
    }


    public override string ToString()
    {
        return $"{Question}\n1.{Answer1}\n2.{Answer2}\n3.{Answer3}\n4.{Answer4}\n";
    }
}
