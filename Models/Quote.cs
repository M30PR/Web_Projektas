using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Quote
    {
        public Quote()
        {
            Contains1s = new HashSet<Contains1>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreatingDate { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Contains1> Contains1s { get; set; }
    }
}
