using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class GameDetail
    {
        public int Id { get; set; }

        public int GId { get; set; }

        public int Point1 { get; set; }

        public int Point2 { get; set; }

        public string OpenId1 { get; set; }

        public string OpenId2 { get; set; }

        public int GameTime { get; set; }

        public int Status { get; set; }

        public int Sort { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
