using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
   public interface IUser
    {
        /// <summary>
        /// 获取申请单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User Get(int Id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(User entity);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(User entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Dels(dynamic[] ids);

        User GetByOpenId(string openId);

        int GetAllCount();

        User GetById(int id);

        List<User> GetAll(string searchName);

        bool DeleteById(int id);
    }
}
