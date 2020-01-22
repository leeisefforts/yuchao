using QRCoder;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        private static SimpleClient<User> udb = new SimpleClient<User>(BaseDb.GetClient());
        private static SimpleClient<ScheduledRecord> sdb = new SimpleClient<ScheduledRecord>(BaseDb.GetClient());
        private static SimpleClient<OnceTotal> otdb = new SimpleClient<OnceTotal>(BaseDb.GetClient());

        private static string AppId = "wx78eab72a6ea9581d";
        private static string mch_id = "1547699641";
        private static string notify_url = "https://fragmenttime.com:8081/api/client/payRedirectApi";
        private static string trade_type = "JSAPI";
        private static string spbill_create_ip = "106.54.146.85";
        private static string key = "RvpZU2lvoDO6ZTlRuywc1sS85qdPNla3";

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

        public static Order CreateOrder(int sid, string openId, decimal total_fee, int venueId)
        {
            Order order = new Order();
            ScheduledRecord sr = sdb.GetById(sid);
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
            string stringA = string.Format(@"appid={0}&body={1}&mch_id={2}&nonce_str={3}&notify_url=https://fragmenttime.com:8081/api/client/payRedirectApi&openid={4}&out_trade_no={5}&spbill_create_ip={6}&total_fee={7}&trade_type=JSAPI", AppId, pay.body, mch_id, nonce_str, openId, pay.out_trade_no, pay.spbill_create_ip, pay.total_fee);
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
            order.Sid = sid;
            int oid = odb.InsertReturnIdentity(order);
            sr.OId = oid;
            sdb.Update(sr);
            return order;
        }


        public static bool SetMsg(string openId, string name, string birthday, int gender, string phone) {

            User user = udb.GetSingle(p=>p.OpenId.Equals(openId));
            user.RealName = name;
            user.RealGender = gender;
            user.Tel = phone;
            user.Birthday = birthday;
            user.Reputation = 100;

            OnceTotal ot = BasicService.GetOt(user.OpenId);
            if (ot == null)
            {
                OnceTotal oo = new OnceTotal()
                {
                    OpenId = user.OpenId,
                    IsCreate = 0,
                    IsOnce = 1
                };

                BasicService.InsertOnce(oo);
            }
            user.CoinNum += 100;
            return udb.Update(user);

        }


        public static bool RefundPay(string orderSn) {
            Order order = odb.GetSingle(p=>p.OrderSn.Equals(orderSn));
            order.OrderSn = BasicService.InitOrderSn();
            string nonce_str = Guid.NewGuid().ToString("N");

            ScheduledRecord sr = sdb.GetById(order.Sid);
            RefundPay rp = new RefundPay()
            {
                appid = AppId,
                mch_id = mch_id,
                sign_type = "MD5",
                out_trade_no = orderSn,
                out_refund_no = order.OrderSn,
                total_fee = sr.Price.ToString(),
                refund_fee = sr.Price.ToString(),
                nonce_str = nonce_str
            };
            string stringA = string.Format(@"appid={0}&mch_id={1}&nonce_str={2}&out_refund_no={3}&out_trade_no={4}&refund_fee={5}&sign_type={6}&total_fee={7}", AppId, mch_id, nonce_str, rp.out_refund_no, orderSn, rp.refund_fee, "MD5", rp.total_fee);
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

            rp.sign = result;
            order.Sign = result;

            string xml = BasicService.Serialize<RefundPay>(rp);

            string response = Post(xml, "https://api.mch.weixin.qq.com/secapi/pay/refund", true, 1000);
            order.Status = 3;
            return odb.Update(order);
        }

        public static string Post(string xml, string url, bool isUseCert, int timeout)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
           new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //是否使用证书
                if (isUseCert)
                {
                    string path = @"E:\\code\\code\\yc_admin\\yuchao\\yuchao.Web\\apiclient_cert.p12";
                    X509Certificate2 cert = new X509Certificate2(path, "1547699641", X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                    request.ClientCertificates.Add(cert);
                }

                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();

                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
              }
            catch (System.Threading.ThreadAbortException e)
            {
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        public static bool SetOnce(OnceTotal ot) {

            return otdb.Update(ot);
        }

        public static bool InsertOnce(OnceTotal ot) {
            return otdb.Insert(ot);
        }

        public static OnceTotal GetOt(string openId) {
            return otdb.GetSingle(p=>p.OpenId.Equals(openId));
        }
    }
}
