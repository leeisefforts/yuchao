using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
    public interface IScheduleRecordService
    {
        List<ScheduledRecord> GetAll(string openId);

        bool Insert(ScheduledRecord record);

        int InsertRId(ScheduledRecord record);

        ScheduledRecord GetById(int id);

        ScheduledRecord GetByOIdVenPage(string openId);



        bool DeleteById(int id);

        bool Update(ScheduledRecord record);

        List<ScheduledRecord> GetByVenueId(int venueId);

        List<ScheduledRecord> GetList(int venueId, string date);

        List<ScheduledRecord> GetListByOpenId(string openId, int isGame);

        List<ScheduledRecord> GetByVenueIdPage(int venueId, int pageIndex, int pageSize);

    }
}
