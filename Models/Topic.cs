using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Quotes = new HashSet<Quote>();
        }

        public string Name { get; set; }
        public int TopicId { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
