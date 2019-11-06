using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
    public class VenueAccount
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string LoginPwd { get; set; }

        public int VenueId { get; set; }

        public string NickName { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
