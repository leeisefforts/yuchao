using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class TeamGameDetail
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string MSOpenId { get; set; }

        public string WSOpenId { get; set; }

        public string MDOpenId { get; set; }

        public string HDOpenId { get; set; }

        public int OpponentId { get; set; }

        public DateTime MatchTime { get; set; }

        public int VenueId { get; set; }

        public DateTime MatchDate { get; set; }
    }
}
