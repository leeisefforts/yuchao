using SqlSugar;
using System;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class RefereeApplyService: BaseDb, IRefereeApply
    {
        public SimpleClient<RefereeApplyEntity> rdb = new SimpleClient<RefereeApplyEntity>(BaseDb.GetClient());

        public RefereeApplyEntity Get(int id)
        {
            return rdb.GetById(id);
        }

        public bool Add(RefereeApplyEntity entity)
        {
            return rdb.Insert(entity);
        }

        public bool Update(RefereeApplyEntity entity)
        {
            return rdb.Update(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);
        }
    }
}
