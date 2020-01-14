using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.Model.Extends
{
   public class RankingExtends:Ranking
    {
        public string NickName { get; set; }

        public string AvatarUrl { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string OpenId { get; set; }

        public string LevelName { get; set; }

        public int Status { get; set; }

        public int LevelCount { get; set; }
    }
}
