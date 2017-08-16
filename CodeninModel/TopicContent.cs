using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeninModel
{
    public class TopicContent
    {
        public int TopicContentId { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}