using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.Model.Extends
{
   public class RankingExtends:Ranking
    {
        public string NickName { get; set; }

        public string Language { get; set; }
        public int Gender { get; set; }

        public string AvatarUrl { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string OpenId { get; set; }

        public int LevelId { get; set; }

        public int CoinNum { get; set; }

        public int TotalGame { get; set; }

        public int Reputation { get; set; }

        public int IsReferee { get; set; }

        public int Status { get; set; }
    }
}
