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


        public string UserId { get; set; }

        public string PrepayId { get; set; }

        public string NonceStr { get; set; }
        public string OrderXml { get; set; }

        public long TimeStamp { get; set; }

        public string Sign { get; set; }

    }
}
