using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class Contains1
    {
        public int Id { get; set; }
        public int TagsId { get; set; }

        public virtual Quote IdNavigation { get; set; }
        public virtual Tag Tags { get; set; }
    }
}
