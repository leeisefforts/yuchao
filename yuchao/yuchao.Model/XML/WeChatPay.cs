using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yuchao.Model.XML
{
    //微信支付
    [XmlType("XML")]
    public class WeChatPay
    {
        [XmlElement("appid")]
        public string appid { get; set; }

        [XmlElement("body")]
        public string body { get; set; }

        [XmlElement("mch_id")]
        public string mch_id { get; set; }


        [XmlElement("nonce_str")]
        public string nonce_str { get; set; }

        [XmlElement("notify_url")]
        public string notify_url { get; set; }

        [XmlElement("openid")]
        public string openid { get; set; }

        [XmlElement("out_trade_no")]
        public string out_trade_no { get; set; }

        [XmlElement("spbill_create_ip")]
        public string spbill_create_ip { get; set; }

        [XmlElement("total_fee")]
        public decimal total_fee { get; set; }


        [XmlElement("trade_type")]
        public string trade_type { get; set; }



        [XmlElement("sign")]
        public string sign { get; set; }

    }


    [XmlType("XML")]
    public class RefundPay
    {
        [XmlElement("appid")]
        public string appid { get; set; }
        [XmlElement("mch_id")]
        public string mch_id { get; set; }
        [XmlElement("nonce_str")]
        public string nonce_str { get; set; }
        [XmlElement("sign")]
        public string sign { get; set; }
        [XmlElement("sign_type")]
        public string sign_type { get; set; }
        [XmlElement("out_trade_no")]
        public string out_trade_no { get; set; }
        [XmlElement("out_refund_no")]
        public string out_refund_no { get; set; }
        [XmlElement("total_fee")]
        public string total_fee { get; set; }
        [XmlElement("refund_fee")]
        public string refund_fee { get; set; }


    }
}
