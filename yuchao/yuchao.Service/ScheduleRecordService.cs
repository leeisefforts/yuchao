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

        public int InsertRId(ScheduledRecord record)
        {
            return rdb.InsertReturnIdentity(record);
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
            return rdb.AsQueryable().OrderBy("useTime desc").Where(p => p.VenueId == venueId).ToList();
        }

        public List<ScheduledRecord> GetByVenueIdPage(int venueId, int pageIndex, int pageSize)
        {
            return rdb.AsQueryable().OrderBy("useTime asc").OrderBy("TimeId asc").Where(p =>p.Status!=-1 &&  p.VenueId == venueId && DateTime.Parse(p.UseTime) >= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))).ToPageList(pageIndex, pageSize);
        }

        public List<ScheduledRecord> GetByVId(int venueId)
        {
            return rdb.GetList(p => p.VenueId == venueId && p.Status != -1);
        }

        public ScheduledRecord GetByOIdVenPage(string openId)
        {
            return rdb.AsQueryable().OrderBy("CreateTime desc").First(p=>p.OpenId.Equals(openId));

        }

        public List<ScheduledRecord> GetList(int venueId, string date)
        {
            return rdb.GetList(p => p.VenueId == venueId && p.UseTime.Equals(date) && p.Status != -1);
        }

        public List<ScheduledRecord> GetListByOpenId(string openid, int isGame)
        {
            return rdb.GetList(p => p.OpenId.Equals(openid)&& p.IsGame == isGame && p.Status != -1);
        }

        public List<ScheduledRecord> MatchGame(int venueId, string useTime, int days) {

            int min = 0;
            int max = 1;
            switch (days)
            {
                case 1:
                    min = 1;
                    max = 3;
                    break;
                case 2:
                    min = 4;
                    max = 8;
                    break;
                case 3:
                    min = 9;
                    max = 13;
                    break;
                default:
                    break;
            }
            return rdb.GetList(p=>p.VenueId == venueId && p.UseTime.Equals(useTime) && (p.TimeId > min || p.TimeId< max ) && p.Status == 1);
        }
    }
}
