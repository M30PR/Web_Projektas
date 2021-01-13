using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class PopularTopic
    {
        public int? NumberTopics { get; set; }
        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
