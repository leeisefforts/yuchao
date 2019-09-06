using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Entity
{
  public class Order
    {
        public int Id { get; set; }
        public string OrderSn { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime PayTime { get; set; }
        public int PayStatus { get; set; }
        public int Status { get; set; }
        public int OrderType { get; set; }
        public decimal Money { get; set; }
        public int VenueId { get; set; }
        public DateTime GameTime { get; set; }

    }
}
