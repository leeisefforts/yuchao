﻿using System;
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

        public int IsTeamGame { get; set; }

        public string OpenId { get; set; }

        public int SiteId { get; set; }

        public int Status { get; set; }

        public int IsGame { get; set; }

    }
}