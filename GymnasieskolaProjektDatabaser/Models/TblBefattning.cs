using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblBefattning
    {
        public TblBefattning()
        {
            TblPersonal = new HashSet<TblPersonal>();
        }

        public int BefattningId { get; set; }
        public string Befattning { get; set; }
        public string Avdelning { get; set; }

        public virtual ICollection<TblPersonal> TblPersonal { get; set; }
    }
}
