using QRCoder;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using yuchao.Entity;
using yuchao.Model;
using yuchao.Model.XML;

namespace yuchao.Service
{
    public class BasicService
    {
        private static SimpleClient<China> rdb = new SimpleClient<China>(BaseDb.GetClient());
        private static SimpleClient<Order> odb = new SimpleClient<Order>(BaseDb.GetClient());

        private static string AppId = "wx78eab72a6ea9581d";
        private static string mch_id = "1547699641";
        private static string notify_url = "https://fragmenttime.com:8081/api/client/payRedirect";
        private static string trade_type = "JSAPI";
        private static string spbill_create_ip = "106.54.146.85";
        private static string key = "RvpZU2lvoDO6ZTlRuywc1sS85qdPNlau";

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

        public static Order CreateOrder(string openId , decimal total_fee, int venueId) {
            Order order = new Order();
            order.OrderSn = BasicService.InitOrderSn();
            string nonce_str = Guid.NewGuid().ToString("N");
            WeChatPay pay = new WeChatPay()
            {
                appid = AppId,
                body = "VenueOrder",
                total_fee = total_fee,
                spbill_create_ip = spbill_create_ip,
                nonce_str = nonce_str,
                mch_id = mch_id,
                notify_url = notify_url,
                out_trade_no = order.OrderSn,
                trade_type = trade_type,
                openid = openId
            };
            string stringA = string.Format(@"appid={0}&body={1}&mch_id={2}&nonce_str={3}&notify_url=https://fragmenttime.com:8081/api/client/payRedirect&openid={4}&out_trade_no={5}&spbill_create_ip={6}&total_fee={7}&trade_type=JSAPI", AppId, pay.body, mch_id, nonce_str, openId, pay.out_trade_no, pay.spbill_create_ip, pay.total_fee);
            string stringSignTemp = stringA + "&key=" + key;
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(stringSignTemp));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            string result = sb.ToString().ToUpper();

            pay.sign = result;
            order.Sign = result;

            string xml = BasicService.Serialize<WeChatPay>(pay);
            WeChatResult rxml = new WeChatResult();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                HttpContent httpContent = new StringContent(xml);
                HttpResponseMessage response = httpClient.PostAsync("https://api.mch.weixin.qq.com/pay/unifiedorder", httpContent).Result;
                string statusCode = response.StatusCode.ToString();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    rxml = BasicService.Deserialize<WeChatResult>(result);
                }
            }
            order.Money = total_fee;
            order.OrderType = 1;
            order.CreateTime = DateTime.Now;
            order.VenueId = venueId;
            order.UserId = openId;
            order.PayStatus = 0;
            order.Status = 1;
            order.PrepayId = rxml.prepay_id;
            order.NonceStr = nonce_str;
            order.OrderXml = result;
            order.TimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            odb.Insert(order);
            return order;
        }
    }
}
