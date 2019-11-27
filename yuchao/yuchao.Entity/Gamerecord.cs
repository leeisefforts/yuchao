using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
   public class Gamerecord
    {
        public int Id { get; set; }

        public string WinId { get; set; }

        public string LoseId { get; set; }

        public string GameTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int RefereeId { get; set; }

        public int IsTeamGame { get; set; }

        public int Status { get; set; }

        public int VenueId { get; set; }

        public int SiteId { get; set; }

        public string OpenId { get; set; }
        public string OpenId2 { get; set; }

        public int ScheduleRecordId { get; set; }

        public int ClubId { get; set; }
    }
}
