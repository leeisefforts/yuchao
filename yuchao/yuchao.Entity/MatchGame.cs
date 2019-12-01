using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class MatchGame
    {
        public int Id { get; set; }

        public string OpenId { get; set; }

        public string MatchTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int MatchDays { get; set; }

        public int VenueId { get; set; }

        public int MatchStatus { get; set; }

        public int IsTeam { get; set; }
    }
}
