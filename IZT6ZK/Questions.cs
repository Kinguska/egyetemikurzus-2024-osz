using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK
{
    internal class Questions
    {
        public string Question {  get; set; }
        public string Answer1 {  get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }
        public Topics? TopicOfQuestion { get; set; }

        public Questions() 
        {

        }

        public override string ToString()
        {
            return $"{Question}\n{Answer1}\n{Answer2}\n{Answer3}\n{Answer4}\n";
        }
    }
}
