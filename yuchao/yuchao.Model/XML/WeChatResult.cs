using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yuchao.Model.XML
{
    [XmlType("xml")]
    public class WeChatResult
    {
        [XmlElement("return_code")]
        public string return_code { get; set; }

        [XmlElement("return_msg")]
        public string return_msg { get; set; }

        [XmlElement("appid")]
        public string appid { get; set; }


        [XmlElement("mch_id")]
        public string mch_id { get; set; }

        [XmlElement("nonce_str")]
        public string nonce_str { get; set; }

        [XmlElement("sign")]
        public string sign { get; set; }

        [XmlElement("result_code")]
        public string result_code { get; set; }

        [XmlElement("prepay_id")]
        public string prepay_id { get; set; }

        [XmlElement("trade_type")]
        public string trade_type { get; set; }
    }
}
