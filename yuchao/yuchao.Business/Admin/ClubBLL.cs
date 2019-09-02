using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Service;


namespace yuchao.Business.Admin
{
  public  class ClubBLL
    {
        public ClubServer IService = new Service.ClubServer();
        // 查询      
        public Club GetById(int id)
        {
            return IService.Get(id);
        }
        // 增加
        public bool Insert(Club entity)
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
       public bool Update(Club entity)
        {
            return IService.Update(entity);
        }

        public object DeleteById(dynamic[] ids)
        {
            throw new NotImplementedException();
        }

       
    }
}
