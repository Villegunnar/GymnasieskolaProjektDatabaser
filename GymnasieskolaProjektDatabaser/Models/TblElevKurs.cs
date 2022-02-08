using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblElevKurs
    {
        public int? ElevId { get; set; }
        public int? KursId { get; set; }
        public DateTime? DatumBetyg { get; set; }
        public string Betyg { get; set; }
        public decimal? BetygSiffra { get; set; }

        public virtual TblElev Elev { get; set; }
        public virtual TblKurs Kurs { get; set; }
    }
}
