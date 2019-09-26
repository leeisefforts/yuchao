using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace yuchao.Model.XML
{
    [XmlType("XML")]
    public class PayResultXml
    {
        [XmlElement("return_code")]
        public string return_code { get; set; }

        [XmlElement("return_msg")]
        public string return_msg { get; set; }
    }
}
