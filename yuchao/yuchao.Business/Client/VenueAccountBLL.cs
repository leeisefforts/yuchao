using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model.Extends;

namespace yuchao.Business.Client
{
    public class VenueAccountBLL
    {
        private IVenueAccount IService = new Service.VenueAccountService();

        private IScheduleRecordService RService = new Service.ScheduleRecordService();
        private IUser UService = new Service.UserServer();
        private IVenue VService = new Service.VenueService();
        public VenueAccount Login (string loginName, string loginPwd)
        {
            return IService.Login(loginName, loginPwd);
        }

        public Dictionary<string, object> GetPage(int venueId)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Venue venue = VService.GetById(venueId);
            List<ScheduledRecord> list = RService.GetByVenueId(venueId);
            List<ScheduledRecordExtends> ll = new List<ScheduledRecordExtends>();
            
            list = list.FindAll(p=> DateTime.Compare(DateTime.Parse(p.UseTime), DateTime.Now) >= -1);
            decimal day1 = 0;
            decimal day2 = 0;
            decimal week1 = 0;
            decimal week2 = 0;
            decimal month1 = 0;
            decimal month2 = 0;
            foreach (var item in list)
            {
                if (item.CreateTime.Subtract(DateTime.Now).Days == 0)
                {
                    if (item.IsOnline == 1)
                    {
                        day1 += item.Price;
                    }
                    else {
                        day2 += item.Price;
                    }
                    //如果是今天
                    
                }
                // 判断本周
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = DateTime.Parse(item.UseTime);
                DateTime temp1 = dt1.AddDays(-(int)dt1.DayOfWeek).Date;
                DateTime temp2 = dt2.AddDays(-(int)dt2.DayOfWeek).Date;
                bool result = temp1 == temp2;
                if (result)
                {
                    if (item.IsOnline == 1)
                    {
                        week1 += item.Price;
                    }
                    else
                    {
                        week2 += item.Price;
                    }
                }

                DateTime nowMonth = dt1.AddDays(1 - dt1.Day);
                DateTime endMonth = nowMonth.AddMonths(1).AddDays(-1);
                TimeSpan ts1 = dt2 - nowMonth;
                TimeSpan ts2 = endMonth - dt2;
                if (ts1.Days >= 0 && ts2.Days >= 0)
                {
                    if (item.IsOnline == 1)
                    {
                        month1 += item.Price;
                    }
                    else
                    {
                        month2 += item.Price;
                    }
                }
                if (!string.IsNullOrEmpty(item.OpenId))
                {
                    User user = UService.GetByOpenId(item.OpenId);
                    if (user != null)
                    {
                        item.Tel = user.Tel;
                        item.NickName = user.NickName;
                    }

                }

                ScheduledRecordExtends sr = new ScheduledRecordExtends() { 
                    IsOnline = item.IsOnline,
                    SiteId = item.SiteId,
                    SiteName = VService.GetSiteBySId(item.SiteId).SiteName,
                    StartTime = item.StartTime,
                    Status = item.Status,
                    NickName = item.NickName,
                    OpenId=  item.OpenId,
                    Price = item.Price,
                    Tel = item.Tel,
                    TimeId = item.TimeId,
                    CreateTime = item.CreateTime,
                    EndTime = item.EndTime,
                    Id = item.Id,
                    IsGame = item.IsGame,
                    UseTime = item.UseTime,
                    VenueId = item.VenueId,
                    Week = item.Week,
                    VenueName = string.Empty

                };

                ll.Add(sr);
            }
            dic.Add("1", venue);
            dic.Add("2", ll);
            dic.Add("3", day1);
            dic.Add("4", day2);
            dic.Add("5", week1);
            dic.Add("6", week2);
            dic.Add("7", month1);
            dic.Add("8", month2);
            return dic;
        }

        public bool SetSite(int siteId, JObject values)
        {
                int start = 0;
                int end = 0;
                switch (Convert.ToInt32(values["timeId"]))
                {
                    case 1:
                        start = 10;
                        end = 11;
                        break;
                    case 2:
                        start = 11;
                        end = 12;
                        break;
                    case 3:
                        start = 12;
                        end = 13;
                        break;
                    case 4:
                        start = 13;
                        end = 14;
                        break;
                    case 5:
                        start = 14;
                        end = 15;
                        break;
                    case 6:
                        start = 15;
                        end = 16;
                        break;
                    case 7:
                        start = 16;
                        end = 17;
                        break;
                    case 8:
                        start = 17;
                        end = 18;
                        break;
                    case 9:
                        start = 18;
                        end = 19;
                        break;
                    case 10:
                        start = 19;
                        end = 20;
                        break;
                    case 11:
                        start = 20;
                        end = 21;
                        break;
                    case 12:
                        start = 21;
                        end = 22;
                        break;
                    case 13:
                        start = 22;
                        end = 23;
                        break;
                }

                ScheduledRecord sr = new ScheduledRecord();
                sr.CreateTime = DateTime.Now;
                sr.OpenId = string.Empty;
                sr.IsGame = 0;
                sr.Status = 1;
                sr.SiteId = siteId;
                sr.StartTime = start;
                sr.EndTime = end;
                sr.TimeId = Convert.ToInt32(values["timeId"]);
                sr.VenueId = Convert.ToInt32(values["venueId"]);
                sr.UseTime = values["useTime"].ToString();
                sr.Tel = values["tel"].ToString();
                sr.NickName = values["nickName"].ToString();
                sr.Price = Convert.ToDecimal(values["price"]);
                sr.IsOnline = 0;
                switch (values["week"].ToString())
                {
                    case "周一":
                        sr.Week = 1;
                        break;
                    case "周二":
                        sr.Week = 2;
                        break;
                    case "周三":
                        sr.Week = 3;
                        break;
                    case "周四":
                        sr.Week = 4;
                        break;
                    case "周五":
                        sr.Week = 5;
                        break;
                    case "周六":
                        sr.Week = 6;
                        break;
                    case "周日":
                        sr.Week = 7;
                        break;
                    default:
                        break;
                }

           return  RService.Insert(sr);

        }

        public bool SetAn(int venueId, JObject values ) {
            Venue venue = VService.GetById(venueId);
            venue.Announcement = values["an"].ToString();
            venue.VenueAddress = values["venueAddress"].ToString();
            venue.Desc = values["desc"].ToString();
            return VService.Update(venue);
        }
    }
}
