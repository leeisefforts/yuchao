using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
   public class VenveConsumeService : BaseDb, IVenveConsume
    {
        public SimpleClient<ScheduledRecord> rdb = new SimpleClient<ScheduledRecord>(BaseDb.GetClient());
       

        public List<ScheduledRecord> GetAll()
        {
            return rdb.GetList();
        }
        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }
    }
}
