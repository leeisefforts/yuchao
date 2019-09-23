using QRCoder;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
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

        public static string GetOpenId(string url) {
            string result = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                string statusCode = response.StatusCode.ToString();
              
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        public static int GetInt() {
            Random random = new Random();
           
            return random.Next(1000, 9999);
        }

        public static string InitQrCode(string url) {
            var imgType = Base64QRCode.ImageType.Jpeg;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(5, Color.Black, Color.White, true, imgType);

            return qrCodeImageAsBase64;

        }
    }
}
