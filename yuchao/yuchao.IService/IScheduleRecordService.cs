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

        ScheduledRecord GetById(int id);

        bool DeleteById(int id);

        bool Update(ScheduledRecord record);

        List<ScheduledRecord> GetByVenueId(int venueId);

        List<ScheduledRecord> GetList(int venueId, string date);

        List<ScheduledRecord> GetListByOpenId(string openId, int isGame);

    }
}
