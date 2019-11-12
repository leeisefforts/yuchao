using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class VenueAccountService: BaseDb, IVenueAccount
    {
        public SimpleClient<VenueAccount> rdb = new SimpleClient<VenueAccount>(BaseDb.GetClient());

        public VenueAccount Login(string loginName, string loginPwd) {

            return rdb.GetSingle(p => p.LoginName.Equals(loginName) && p.LoginPwd.Equals(loginPwd));
        }

        public bool Insert(VenueAccount venue) {
            return rdb.Insert(venue);
        }
        public List<VenueAccount> GetAll()
        {
            return rdb.GetList();
        }
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
