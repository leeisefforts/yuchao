﻿using SqlSugar;
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
        //查询
        public User Get(int Id)
        {
            return rdb.GetSingle(p => p.Id == Id);
        }
        public User GetById(int id)
        {
            return rdb.GetById(id);
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
        
        public User GetByOpenId(string openId) {
            return rdb.GetSingle(p=>p.OpenId.Equals(openId));
        }
    }
}