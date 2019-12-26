using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Client
{
    public class ScheduledRecordApiBLL
    {
        private IScheduleRecordService IService = new Service.ScheduleRecordService();
        private IVenue VService = new Service.VenueService();
        private IUser UService = new Service.UserServer();
        private IGamerecord GService = new Service.GamerecordService();


        public Order CreateSc(string openId, JObject values)
        {
            int sid = 0;
            foreach (var item in values["list"])
            {
                int siteId = Convert.ToInt32(item["areaId"]);

                int start = 0;
                int end = 0;
                switch (Convert.ToInt32(item["timeId"]))
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
                sr.OpenId = openId;
                sr.IsGame = 0;
                sr.Status = -1;
                sr.SiteId = siteId;
                sr.StartTime = start;
                sr.EndTime = end;
                sr.TimeId = Convert.ToInt32(item["timeId"]);
                sr.VenueId = Convert.ToInt32(values["venueId"]);
                sr.UseTime = values["useTime"].ToString();
                sr.IsOnline = 1;
                sr.Price = Convert.ToDecimal(values["total_fee"]);
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
                
                sid = IService.InsertRId(sr);
            }
            Order order =BasicService.CreateOrder(sid, openId, Convert.ToDecimal(values["total_fee"]) ,Convert.ToInt32(values["venueId"]));

           return order;
        }

        public bool SetSStatus(int sid) {

            ScheduledRecord sr = IService.GetById(sid);
            sr.Status = 1;
            User user = UService.GetByOpenId(sr.OpenId);
            user.CoinNum += Convert.ToInt32( sr.Price);
            user.LevelExperience += Convert.ToInt32(sr.Price);
            UService.Update(user);
            return IService.Update(sr);
        }



        public void SelectEmptySite(int venueId)
        {
            List<ScheduledRecord> list = IService.GetByVenueId(venueId);

        }

        public List<ScheduledRecord> GetList(int venueId, string date) {
            return IService.GetList(venueId, date);
        }

        public List<ScheduledRecordExtends> GetListByOpenId(string openId, int isGame)
        {
            List<ScheduledRecord> list =  IService.GetListByOpenId(openId, isGame);
            List<ScheduledRecordExtends> res = new List<ScheduledRecordExtends>();

            // 查询俱乐部团体赛
            List<TeamGameDetail> tgd = GService.GetByOpenId(openId);
            foreach (var item in tgd)
            {

            }


            foreach (var item in list)
            {
                Venue venue = VService.GetById(item.VenueId);
                Site site = VService.GetSiteBySId(item.SiteId);

                ScheduledRecordExtends se = new ScheduledRecordExtends()
                {
                    CreateTime = item.CreateTime,
                    EndTime = item.EndTime,
                    VenueId = item.VenueId,
                    VenueName = venue == null?"待匹配" : venue.VenueName,
                    SiteId = item.SiteId,
                    SiteName = site==null ? "待匹配" : site.SiteName,
                    Id = item.Id,
                    StartTime = item.StartTime,
                    Status = item.Status,
                    IsGame = item.IsGame,
                    OpenId = item.OpenId,
                    TimeId =item.TimeId,
                    UseTime = item.UseTime,
                    Week = item.Week

                };
                res.Add(se);
            }

            return res;
        }
    }
}
