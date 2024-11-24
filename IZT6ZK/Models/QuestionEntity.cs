using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Models;

internal class QuestionEntity
{
    public int QuestionId { get; set; }
    public string Question { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }
    public string Answer3 { get; set; }
    public string Answer4 { get; set; }
    public string CorrectAnswer { get; set; }
    public TopicEntity? Topic { get; set; }
    public int? TopicId { get; set; }


    public override string ToString()
    {
        return $"{Question}\n-{Answer1}\n-{Answer2}\n-{Answer3}\n-{Answer4}\n";
    }
}
