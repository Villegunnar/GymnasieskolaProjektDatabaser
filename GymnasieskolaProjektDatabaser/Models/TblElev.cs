using GymnasieskolaProjektDatabaser.Data;
using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblElev
    {
        public int ElevId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Personnummer { get; set; }
        public int KlassId { get; set; }

        public virtual TblKlass Klass { get; set; }



    }
}
