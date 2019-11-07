using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Service;

namespace yuchao.Business.Admin
{
   public class UserBLL
    {
        public IUser IService = new Service.UserServer();
        // 查询      
        public object GetById(int id)
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

        // 修改
  
        public bool Update(User user)
        {
            User user1 = IService.GetById(user.Id);
            user1.Language = user.Language;
            user1.NickName = user.NickName;
            user1.Province = user.Province;
            user1.Gender = user.Gender;
            user1.AvatarUrl = user.AvatarUrl;
            user1.City = user.City;
            user1.Country = user.Country;
            return IService.Update(user);
        }

        public List<User> GetList() {
            return IService.GetAll();
        }

      
    }
}
