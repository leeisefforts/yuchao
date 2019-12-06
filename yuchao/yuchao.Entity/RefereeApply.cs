using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class RefereeApply
    {
        public int Id { get; set; }

        public string OpenId { get; set; }

        public int Phone { get; set; }

        public int ApplyUserId { get; set; }

        public int ApplyResult { get; set; }

        public string Name { get; set; }

        public DateTime ApplyDate { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
