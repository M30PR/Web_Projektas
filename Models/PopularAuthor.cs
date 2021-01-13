using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class PopularAuthor
    {
        public int? NumberAuthors { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
