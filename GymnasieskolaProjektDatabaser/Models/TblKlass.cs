using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblKlass
    {
        public TblKlass()
        {
            TblElev = new HashSet<TblElev>();
        }

        public int KlassId { get; set; }
        public int SkolId { get; set; }
        public string KlassNamn { get; set; }

        public virtual TblSkola Skol { get; set; }
        public virtual ICollection<TblElev> TblElev { get; set; }
    }
}
