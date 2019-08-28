using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Service;

namespace yuchao.Business.Admin
{
  public  class ClubBLL
    {
        public ClubServer IService = new Service.ClubServer();

        public Club GetById(int id)
        {
            return IService.Get(id);
        }
        public bool Insert(Club entity)
        {
            return IService.Add(entity);
        }
    }
}
