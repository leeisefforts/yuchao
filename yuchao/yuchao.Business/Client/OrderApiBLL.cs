﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Model.XML;
using yuchao.Service;

namespace yuchao.Business.Client
{
    public class OrderApiBLL
    {
        //订单
        private OrderService IService = new OrderService();
        private VenueService LService = new VenueService();
        private ScheduleRecordService SService = new ScheduleRecordService();
        private UserServer Uservice = new UserServer();
        private LevelService LevelService = new LevelService();

        private static string AppId = "wx78eab72a6ea9581d";
        private static string mch_id = "1547699641";
        private static string notify_url = "https://fragmenttime.com:8081/api/client/payRedirectApi";
        private static string trade_type = "JSAPI";
        private static string spbill_create_ip = "106.54.146.85";
        private static string key = "RvpZU2lvoDO6ZTlRuywc1sS85qdPNla3";

        public OrderExtends GetByOpenId(string openId)
        {
            // 根据VenueId获取Order
            Order order = IService.GetByOpenId(openId);
            OrderExtends orderInfo = new OrderExtends();
            if (order != null)
            {
                orderInfo.Id = order.Id;
                orderInfo.CreateTime = order.CreateTime;
                orderInfo.GameTime = order.GameTime;
                orderInfo.Money = order.Money;
                orderInfo.OrderSn = order.OrderSn;
                orderInfo.OrderType = order.OrderType;
                orderInfo.PayStatus = order.PayStatus;
                orderInfo.PayTime = order.PayTime;
                orderInfo.Status = order.Status;
                orderInfo.VenueId = order.VenueId;
                orderInfo.VenueName = LService.GetById(order.VenueId).VenueName;
                orderInfo.Score = LService.GetById(order.VenueId).Score;
                orderInfo.VenueAddress = LService.GetById(order.VenueId).VenueAddress;
                orderInfo.VenueImg = LService.GetById(order.VenueId).VenueImg;
                orderInfo.AvePrice = LService.GetById(order.VenueId).AvePrice;
                orderInfo.NickName = Uservice.GetByOpenId(openId).NickName;
            }
            return orderInfo;
        }
        public Order CreateOrder(int sid, string openId, JObject values)
        {
            Order order = new Order();
            order.OrderSn = BasicService.InitOrderSn();
            string nonce_str = Guid.NewGuid().ToString("N");
            WeChatPay pay = new WeChatPay()
            {
                appid = AppId,
                body = "VenueOrder",
                total_fee = Convert.ToDecimal(values["total_fee"]),
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
            order.Money = Convert.ToDecimal(values["total_fee"]);
            order.OrderType = 1;
            order.CreateTime = DateTime.Now;
            order.VenueId = Convert.ToInt32(values["venueId"]);
            order.UserId = openId;
            order.PayStatus = 0;
            order.Status = 1;
            order.PrepayId = rxml.prepay_id;
            order.NonceStr = nonce_str;
            order.OrderXml = result;
            order.Sign = pay.sign;
            order.Sid = sid;
            IService.Insert(order);
            return order;
        }

        public Dictionary<string, object> GetOrderDetail(string openId, int isGame, int sId)
        {

            Order order = IService.GetBySId(sId);
            Venue venue = LService.GetById(order.VenueId);
            OrderExtends orderInfo = new OrderExtends();
            User user = Uservice.GetByOpenId(openId);
            Level level = LevelService.GetById(user.LevelId);
            if (order != null)
            {
                orderInfo.Id = order.Id;
                orderInfo.CreateTime = order.CreateTime;
                orderInfo.GameTime = order.GameTime;
                orderInfo.Money = order.Money;
                orderInfo.OrderSn = order.OrderSn;
                orderInfo.OrderType = order.OrderType;
                orderInfo.PayStatus = order.PayStatus;
                orderInfo.PayTime = order.PayTime;
                orderInfo.Status = order.Status;
                orderInfo.VenueId = order.VenueId;
                orderInfo.VenueName = venue == null ? "待匹配": venue.VenueName;
                orderInfo.Score = venue == null? "": venue.Score;
                orderInfo.VenueAddress = venue == null ? string.Empty: venue.VenueAddress;
                orderInfo.VenueImg = venue == null ? "" :venue.VenueImg;
                orderInfo.AvePrice = venue == null ? 0: venue.AvePrice;
                orderInfo.LevelName = level == null ? "无段位" : level.LevelName;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();

            ScheduledRecord item = SService.GetById(sId);
            Site site = LService.GetSiteBySId(item.SiteId);

            ScheduledRecordExtends se = new ScheduledRecordExtends()
            {
                CreateTime = item.CreateTime,
                EndTime = item.EndTime,
                VenueId = item.VenueId,
                VenueName = venue == null ? "待匹配" : venue.VenueName,
                SiteId = item.SiteId,
                SiteName = site ==null ? "待匹配": site.SiteName,
                Id = item.Id,
                StartTime = item.StartTime,
                Status = item.Status,
                IsGame = item.IsGame,
                OpenId = item.OpenId,
                TimeId = item.TimeId,
                UseTime = item.UseTime,
                Week = item.Week

            };

            dic.Add("1", orderInfo);
            dic.Add("2", se);

            return dic;
        }

    }
}
