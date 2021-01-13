using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Contains1s = new HashSet<Contains1>();
        }

        public string Name { get; set; }
        public int TagsId { get; set; }

        public virtual ICollection<Contains1> Contains1s { get; set; }
    }
}
