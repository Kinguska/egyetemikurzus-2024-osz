using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Db
{
    internal interface IDbManager
    {
        public MyDbContext DbConnect();
        public void CreateTopic(string topicName);
        public void SelectTopic();
        public void DeleteTopic();

        public void CreateQuestion(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer, TopicEntity? topicEntity);
        public void SelectQuestion();
        public void DeleteQuestion();

    }
}
