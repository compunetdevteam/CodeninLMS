using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeninModel
{
    public class TopicQuiz
    {
        public int TopicQuizId { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }

    public class ModuleQuiz
    {
        public int ModuleQuizId { get; set; }
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }
    }
}