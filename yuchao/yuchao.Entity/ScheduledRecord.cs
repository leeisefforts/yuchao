using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class ScheduledRecord
    {
        public int Id { get; set; }

        public int VenueId { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int Week { get; set; }


        public string OpenId { get; set; }

        public int SiteId { get; set; }

        public int Status { get; set; }

        public int IsGame { get; set; }

        public int TimeId { get; set; }

        public string UseTime { get; set; }

        public int IsOnline { get; set; }

        public string Tel { get; set; }

        public string NickName { get; set; }

        public decimal Price { get; set; }

    }
}
