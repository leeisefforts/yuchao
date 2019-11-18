using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{

    public interface IVenveConsume
    {
        List<ScheduledRecord> GetAll();
        bool DeleteById(int id);
    }
}
