using SqlSugar;
using System;
using System.Collections.Generic;
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

        public RefereeApply GetById(int id)
        {
            return rdb.GetById(id);
        }

        public bool Add(RefereeApply entity)
        {
            return rdb.Insert(entity);
        }

        public bool Update(RefereeApply entity)
        {
            return rdb.Update(entity);
        }

        public bool Update()
        {
            return rdb.Update();
        }

        public object Dels(int id)
        {
            return rdb.DeleteById(id);
        }

        bool IRefereeApply.Dels(dynamic[] ids)
        {
            return rdb.DeleteById(ids);
        }

        public List<RefereeApply> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
