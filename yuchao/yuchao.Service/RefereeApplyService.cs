using SqlSugar;
using System;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class RefereeApplyService : BaseDb, IRefereeApply
    {
        public SimpleClient<RefereeApply> rdb = new SimpleClient<RefereeApply>(BaseDb.GetClient());

        public RefereeApply Get(int id)
        {
            return rdb.GetSingle(p => p.ApplyUserId == id);
        }

        public bool Add(RefereeApply entity)
        {
            return rdb.Insert(entity);
        }

        public bool Update(RefereeApply entity)
        {
            return rdb.Update(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);
        }

        public object Dels(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public RefereeApply GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
