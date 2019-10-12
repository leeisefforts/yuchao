﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class VenueService : BaseDb, IVenue
    {
        public SimpleClient<Venue> rdb = new SimpleClient<Venue>(BaseDb.GetClient());
        public SimpleClient<Site> sdb = new SimpleClient<Site>(BaseDb.GetClient());

        public List<Venue> GetAll()
        {
            return rdb.GetList();
        }
        public List<Site> GetSiteById(int id)
        {
            return sdb.GetList(p=>p.VenueId == id);
        }
        public bool Insert(Venue venue)
        {
            return rdb.Insert(venue);
        }

        public Venue GetById(int id)
        {
            return rdb.GetById(id);
        }

        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }

        public bool Update(Venue venue)
        {
            return rdb.Update(venue);
        }

        public Site GetSiteBySId(int id)
        {
            return sdb.GetById(id);
        }
    }
}
