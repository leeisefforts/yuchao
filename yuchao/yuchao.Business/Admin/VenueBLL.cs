using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
    public class VenueBLL
    {
        private IVenue IService = new Service.VenueService();
        private IScheduleRecordService RService = new Service.ScheduleRecordService();

        public List<VenueExtend> GetAll()
        {
            List<Venue> list = IService.GetAll();
            List<VenueExtend> ve = new List<VenueExtend>();
            foreach (var item in list)
            {
                VenueAccount va = IService.GetVenueAccount(item.Id);

                VenueExtend vv = new VenueExtend()
                {
                    VenueName = item.VenueName,
                    Score = item.Score,
                    Account = va == null ? string.Empty : va.LoginName,
                    Announcement = item.Announcement,
                    APrice = item.APrice,
                    Desc = item.Desc,
                    AvePrice = item.AvePrice,
                    VenueAddress = item.VenueAddress,
                    Id = item.Id,
                    Lat = item.Score,
                    Status = item.Status,
                    Lng = item.Lng,
                    MPrice = item.MPrice,
                    NPrice = item.NPrice,
                    VenueImg = item.VenueImg,
                    Pwd = va == null? string.Empty : va.LoginPwd,
                };

                ve.Add(vv);
            }


            return ve;
        }

        public bool SetAccount(int id,string name,string pwd) {
            VenueAccount va = IService.GetVenueAccount(id);
            if (va == null)
            {
                va = new VenueAccount()
                {
                    CreateTime = DateTime.Now,
                    LoginName = name,
                    LoginPwd = pwd,
                    NickName = name,
                    VenueId = id
                };

                return IService.InsertVAccount(va);
            }
            else {
                va.LoginName = name;
                va.LoginPwd = pwd;

                return IService.UpdateVAccount(va);
            }

        
        }


        public Dictionary<string, object> GetVenList(string openId)
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<Venue> list = IService.GetAll();
            ScheduledRecord sr = RService.GetByOIdVenPage(openId);
            if (sr == null)
            {
                dic.Add("1", "");
            }
            else
            {

                Venue venue = IService.GetById(sr.VenueId);
                dic.Add("1", venue);
            }

            dic.Add("2", list);


            return dic;
        }



        public List<Site> GetSiteById(int id)
        {
            return IService.GetSiteById(id);
        }
        public Venue GetById(int id)
        {
            return IService.GetById(id);
        }
        public bool Insert(Venue venue)
        {
            return IService.Insert(venue);
        }

        public bool InsertSite(Site site)
        {
            return IService.InsertSite(site);
        }

        public bool UpdateSite(Site site)
        {
            return IService.UpdateSite(site);
        }

        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }

        public bool DeleteSite(int id)
        {
            return IService.DeleteSite(id);
        }

        public bool Update(Venue venue)
        {
            Venue l = IService.GetById(venue.Id);
            l.VenueName = venue.VenueName;
            l.VenueImg = venue.VenueImg;
            l.VenueAddress = venue.VenueAddress;
            return IService.Update(venue);
        }

        public bool SetSite(int id, Venue obj, List<Site> list, JObject values)
        {
            bool result = false;
            if (id != 0)
            {
                obj.MPrice = Convert.ToDecimal(values["mPrice"]);
                obj.NPrice = Convert.ToDecimal(values["nPrice"]);
                obj.APrice = Convert.ToDecimal(values["aPrice"]);


                IService.Update(obj);
                foreach (var item in list)
                {
                    item.NPrice = obj.NPrice;
                    item.MPrice = obj.MPrice;
                    item.APrice = obj.APrice;
                    result = IService.UpdateSite(item);
                }

            }
            return result;
        }


        public bool SetSitePrice(int id, JObject values)
        {

            Site obj = IService.GetSiteBySId(id);
            obj.MPrice = Convert.ToDecimal(values["mPrice"]);
            obj.NPrice = Convert.ToDecimal(values["nPrice"]);
            obj.APrice = Convert.ToDecimal(values["aPrice"]);
            bool result = IService.UpdateSite(obj);

            return result;

        }

    }
}
