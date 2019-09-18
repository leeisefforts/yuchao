using SqlSugar;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Service
{
    public class BasicService
    {
        private static SimpleClient<China> rdb = new SimpleClient<China>(BaseDb.GetClient());

        public static string InitOrderSn() {

            return Guid.NewGuid().ToString("N");
        }

        public static List<China> GetAllPro() {

            return rdb.GetList(p=>p.Pid ==0);
        }

        public static List<China> GetCity(int pid) {
            return rdb.GetList(p=>p.Pid==pid);
        }

        public static string Serialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            serializer.Serialize(writer, obj);
            string xml = writer.ToString();
            writer.Close();
            writer.Dispose();

            return xml;
        }

        public static T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);
            T result = (T)(serializer.Deserialize(reader));
            reader.Close();
            reader.Dispose();

            return result;
        }
    }
}
