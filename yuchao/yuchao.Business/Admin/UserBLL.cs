using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Service;

namespace yuchao.Business.Admin
{
   public class UserBLL
    {
        public UserServer IService = new Service.UserServer();
        // 查询      
        public User GetById(int id)
        {
            return IService.Get(id);
        }
        // 增加
        public bool Insert(User entity)
        {
            return IService.Add(entity);
        }
        // 删除
        public bool DeleteByIds(dynamic[] ids)
        {

            return IService.Dels(ids);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public bool Update(User entity)
        {
            return IService.Update(entity);
        }

    }
}
