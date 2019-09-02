using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class VerifieduserServer : BaseDb, IVerifieduser
    {
        public SimpleClient<Verifieduser> rdb = new SimpleClient<Verifieduser>(BaseDb.GetClient());

        public List<Verifieduser> GetAll()
        {
            return rdb.GetList();
        }

        public bool Insert(Verifieduser verifieduser)
        {
            return rdb.Insert(verifieduser);
        }

        public Verifieduser GetById(int id)
        {
            return rdb.GetById(id);
        }

        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }

        public bool Update(Verifieduser verifieduser)
        {
            return rdb.Update(verifieduser);
        }
    }
}
