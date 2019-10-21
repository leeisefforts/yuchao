using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class ClubTotal
    {
        public int Id { get; set; }

        public int ClubId { get; set; }

        public int TotalGame { get; set; }

        public string WinRate { get; set; }

        public int WinCount { get; set; }
    }
}
