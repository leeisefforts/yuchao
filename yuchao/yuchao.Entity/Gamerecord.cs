using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
   public class Gamerecord
    {
        public int Id { get; set; }
        public int WinId { get; set; }
        public int LoseId { get; set; }
        public DateTime GameTime { get; set; }
        public DateTime CreateTime { get; set; }
        public int RefereeId { get; set; }
        public int IsTeamGame { get; set; }
        public int Statue { get; set; }
      








    }
}
