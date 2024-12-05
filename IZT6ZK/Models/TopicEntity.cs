using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Models;
internal class TopicEntity
{
    public int TopicId { get; set; }
    public string TopicName { get; set; }
    public List<QuestionEntity> Questions { get; set; }
}
