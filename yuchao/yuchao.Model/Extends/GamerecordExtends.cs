using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.Model.Extends
{
   public class GamerecordExtends: Gamerecord
    {
        public string VenueName { get; set; }
        public string Score { get; set; }
        public string VenueAddress { get; set; }
        public string VenueImg { get; set; }
        public decimal AvePrice { get; set; }

    }

    public class GamerecordReExtends : Gamerecord
    {
        public string VenueName { get; set; }

        public string Score { get; set; }

        public string VenueAddress { get; set; }

        public string VenueImg { get; set; }

        public decimal AvePrice { get; set; }

        public string OpenName2 { get; set; }

        public string OpenName1 { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

    }
}
