using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;
using yuchao.Model.Extends;

namespace yuchao.Service
{
    public class UserServer : BaseDb, IUser
    {
        public SimpleClient<User> rdb = new SimpleClient<User>(BaseDb.GetClient());
        //查询
        public User Get(int Id)
        {
            return rdb.GetSingle(p => p.Id == Id);
        }

        //查询数量
        public int GetAllCount() {
            return rdb.Count(p=>p.Status == 1);
        }
        public User GetById(int id)
        {
            return rdb.GetById(id);
        }

        public List<User> GetByClubId(int clubId)
        {
            return rdb.GetList(p=>p.ClubId == clubId);
        }
        //增加
        public bool Add(User entity)
        {
            return rdb.Insert(entity);
        }
        //修改
        public bool Update(User entity)
        {
            return rdb.Update(entity);
        }
        //删除
        public bool Dels(dynamic[] ids)
        {
            return rdb.DeleteByIds(ids);
        }
        //场馆查询
        public User GetByOpenId(string openId) {
            return rdb.GetSingle(p=>p.OpenId.Equals(openId));
        }

        //预约管理


        public bool Insert(User user) {
            return rdb.Insert(user);
        }

        public List<User> GetAll() {
            return rdb.GetList();
        }

        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }
    }
}
