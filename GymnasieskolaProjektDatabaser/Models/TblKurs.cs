using GymnasieskolaProjektDatabaser.Data;
using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblKurs
    {
        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public int? LärareId { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? SlutDatum { get; set; }

        public virtual TblPersonal Lärare { get; set; }

    }
}
