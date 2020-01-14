using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class Venue
    {
        public int Id { get; set; }

        public string VenueName { get; set; }

        public string Score { get; set; }

        public string VenueAddress { get; set; }

        public string VenueImg { get; set; }

        public decimal AvePrice { get; set; }

        public int Status { get; set; }

        public decimal MPrice { get; set; }

        public decimal APrice { get; set; }

        public decimal NPrice { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public string Announcement { get; set; }

        public string Desc { get; set; }

    }

    public class VenueExtend : Venue { 

        public string Account { get; set; }

        public string Pwd { get; set; }
    
    }
}
