using SqlSugar;
using System;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Service
{
    public class RefereeApplyService
    {
        public SimpleClient<RefereeApplyEntity> rdb = new SimpleClient<RefereeApplyEntity>(BaseDb.GetClient());

        public RefereeApplyEntity Get(long id)
        {
            return rdb.GetById(id);
        }
    }
}
