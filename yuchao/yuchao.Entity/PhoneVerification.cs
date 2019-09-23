using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class PhoneVerification
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string UserId { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
