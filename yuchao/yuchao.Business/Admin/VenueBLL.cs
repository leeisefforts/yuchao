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

        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }

        public bool Update(Venue venue)
        {
            Venue l = IService.GetById(venue.Id);
            l.VenueName = venue.VenueName;
            l.VenueImg = venue.VenueImg;
            l.VenueAddress = venue.VenueAddress;
            return IService.Update(venue);
        }

    }
}
