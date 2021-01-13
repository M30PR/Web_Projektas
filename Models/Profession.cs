using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Profession
    {
        public Profession()
        {
            Authors = new HashSet<Author>();
        }

        public string Name { get; set; }
        public int ProfesionId { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
