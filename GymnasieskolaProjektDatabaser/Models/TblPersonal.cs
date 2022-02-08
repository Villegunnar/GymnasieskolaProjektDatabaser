using GymnasieskolaProjektDatabaser.Data;
using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Models
{
    public partial class TblPersonal
    {
        public TblPersonal()
        {
            TblKurs = new HashSet<TblKurs>();
        }

        public int PersonalId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int? BefattningId { get; set; }
        public decimal? Månadslön { get; set; }
        public DateTime? AnställningsDatum { get; set; }

        public virtual TblBefattning Befattning { get; set; }
        public virtual ICollection<TblKurs> TblKurs { get; set; }


    }
}
