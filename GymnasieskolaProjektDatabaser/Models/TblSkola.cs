using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblSkola
    {
        public TblSkola()
        {
            TblKlass = new HashSet<TblKlass>();
        }

        public int Id { get; set; }
        public string SkolNamn { get; set; }

        public virtual ICollection<TblKlass> TblKlass { get; set; }
    }
}
