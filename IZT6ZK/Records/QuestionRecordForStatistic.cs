using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Records;
//public record QuestionRecordForStatistic(string Question, string CorrectAnswer, string UserAnswer);
public record QuestionRecordForStatistic
{
    public string Question { get; init; }
    public string CorrectAnswer { get; init; }
    public string UserAnswer { get; set; }
    public QuestionRecordForStatistic(string question, string correctAnswer, string userAnswer)
    {
        Question = question;
        CorrectAnswer = correctAnswer;
        UserAnswer = userAnswer;
    }

    public override string ToString()
    {
        return $"Question: {Question}; Correct answer: {CorrectAnswer}; Your answer: {UserAnswer}";
    }
}