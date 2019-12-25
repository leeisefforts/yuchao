using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class Club
    {
        public int Id { get; set; }

        public string ClubName { get; set; }

        public string ClubDesc { get; set; }

        public string ClubLogo { get; set; }

        public string ClubCity { get; set; }

        public string ClubArea { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public string OpenId { get; set; }

        public int PersonCount { get; set; }
    }

}
