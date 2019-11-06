using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

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

            
            list = list.FindAll(p=> DateTime.Compare(DateTime.Parse(p.UseTime), DateTime.Now) >= 0);
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.OpenId))
                {
                    User user = UService.GetByOpenId(item.OpenId);
                    if (user != null)
                    {
                        item.Tel = user.Tel;
                        item.NickName = user.NickName;
                    }

                }
            }
            dic.Add("1", venue);
            dic.Add("2", list);
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
    }
}
