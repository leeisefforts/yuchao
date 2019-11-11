using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
   public class VenveConsumeBLL
    {
        private  IVenveConsume IService = new Service.VenveConsumeService();

        public List<ScheduledRecord> GetAll()
        {
            return IService.GetAll();
        }
        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }
    }
}
