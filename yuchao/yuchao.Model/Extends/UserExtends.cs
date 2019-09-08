using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.Model.Extends
{
    public class UserExtends: User
    {
        public string LevelName { get; set; }
        public string OrderSn { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime PayTime { get; set; }
        public int PayStatus { get; set; }
        public int OrderType { get; set; }
        public decimal Money { get; set; }
        public DateTime GameTime { get; set; }
    }

}
