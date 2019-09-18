using System;
using System.Collections.Generic;
using System.Text;

namespace yuchao.Model
{
    public class WeChatPrePay
    {
        public string out_trade_no { get; set; }

        public string appid { get; set; }

        public string mch_id { get; set; }

        public string nonce_str { get; set; }

        public string sign { get; set; }

        public string body { get; set; }

        public int total_fee { get; set; }

        public string spbill_create_ip { get; set; }

        public string notify_url { get; set; }

        public string trade_type { get; set; }


    }
}
