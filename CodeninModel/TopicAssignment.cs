using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeninModel
{
    public class TopicAssignment
    {
        public int TopicAssignmentId { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}