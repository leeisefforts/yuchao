using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
    public class UserServer : BaseDb, IUser
    {
        public SimpleClient<User> rdb = new SimpleClient<User>(BaseDb.GetClient());

        public User Get(int Id)
        {
            return rdb.GetSingle(p => p.Id == Id);
        }

        public bool Add(User entity)
        {
            return rdb.Insert(entity);
        }

        public bool Update(User entity)
        {
            return rdb.Update(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);

        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
