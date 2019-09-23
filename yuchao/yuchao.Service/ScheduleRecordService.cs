using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class ScheduleRecordService : BaseDb , IScheduleRecordService
    {
        public SimpleClient<ScheduledRecord> rdb = new SimpleClient<ScheduledRecord>(BaseDb.GetClient());

        public List<ScheduledRecord> GetAll(string openId)
        {
            return rdb.GetList(p => p.OpenId.Equals(openId));
        }

        public bool Insert(ScheduledRecord record)
        {
            return rdb.Insert(record);
        }

        public ScheduledRecord GetById(int id)
        {
            return rdb.GetById(id);
        }

        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }

        public bool Update(ScheduledRecord record)
        {
            return rdb.Update(record);
        }
        public List<ScheduledRecord> GetByVenueId(int venueId)
        {
            return rdb.GetList(p => p.VenueId ==venueId);
        }

        public List<ScheduledRecord> GetByVId(int venueId)
        {
            return rdb.GetList(p => p.VenueId == venueId);
        }

        public List<ScheduledRecord> GetList(int venueId, string date)
        {
            return rdb.GetList(p => p.VenueId == venueId && p.UseTime.Equals(date));
        }
    }
}
