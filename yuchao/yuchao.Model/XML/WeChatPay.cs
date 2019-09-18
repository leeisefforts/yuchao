using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yuchao.Model.XML
{
    [XmlType("XML")]
    public class WeChatPay
    {
        [XmlElement("appid")]
        public string appid { get; set; }

        [XmlElement("mch_id")]
        public string mch_id { get; set; }

        [XmlElement("device_info")]
        public string device_info { get; set; }

        [XmlElement("body")]
        public string body { get; set; }

        [XmlElement("nonce_str")]
        public string nonce_str { get; set; }

        [XmlElement("sign")]
        public string sign { get; set; }

        [XmlElement("out_trade_no")]
        public string out_trade_no { get; set; }

        [XmlElement("total_fee")]
        public int total_fee { get; set; }

        [XmlElement("spbill_create_ip")]
        public string spbill_create_ip { get; set; }

        [XmlElement("trade_type")]
        public string trade_type { get; set; }

        [XmlElement("notify_url")]
        public string notify_url { get; set; }

    }
}
