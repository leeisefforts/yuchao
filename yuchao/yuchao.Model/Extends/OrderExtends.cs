using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.Model.Extends
{
    public class OrderExtends : Order
    {
        public string VenueName { get; set; }
        public string Score { get; set; }
        public string VenueAddress { get; set; }
        public string VenueImg { get; set; }
        public decimal AvePrice { get; set; }
        public string NickName { get; set; }

        public string LevelName { get; set; }
    }
}
