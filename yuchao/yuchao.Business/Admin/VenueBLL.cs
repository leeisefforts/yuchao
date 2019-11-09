﻿using Newtonsoft.Json.Linq;
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

        public List<Venue> GetAll()
        {
            return IService.GetAll();
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

        public bool SetSite(int id,Venue obj, List<Site> list, JObject values) {
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


        public bool SetSitePrice(int id, JObject values) {

            Site obj = IService.GetSiteBySId(id);
            obj.MPrice = Convert.ToDecimal(values["mPrice"]);
            obj.NPrice = Convert.ToDecimal(values["nPrice"]);
            obj.APrice = Convert.ToDecimal(values["aPrice"]);
            bool result = IService.UpdateSite(obj);

            return result;

        }

    }
}
