using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class RefereeApply
    {
        public int Id { get; set; }

        public int ApplyUserId { get; set; }

        public int ApplyResult { get; set; }

        public DateTime ApplyDate { get; set; }

    }
}
