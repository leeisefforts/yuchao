using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class ClubClose
    {
        public int Id { get; set; }

        public int ClubId { get; set; }

        public string CloseTime { get; set; }

        public DateTime CreateTime { get; set; }

        public string OpenId { get; set; }
    }
}
