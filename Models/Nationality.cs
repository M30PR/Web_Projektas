using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Nationality
    {
        public Nationality()
        {
            Authors = new HashSet<Author>();
        }

        public string Name { get; set; }
        public int NationalityId { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
