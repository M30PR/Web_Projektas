using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Author
    {
        public Author()
        {
            Quotes = new HashSet<Quote>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public int AuthorId { get; set; }
        public int NationalityId { get; set; }
        public int ProfesionId { get; set; }

        public virtual Nationality Nationality { get; set; }
        public virtual Profession Profesion { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
