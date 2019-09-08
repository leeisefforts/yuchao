using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;

namespace yuchao.IService
{
  public  interface IOrder
    {

        List<Order> GetAll();

        bool Insert(Order order);

        Order GetById(int id);

        bool DeleteById(int id);

        bool Update(Order order);

        Order GetById(object id);
        //场馆查询
        Order GetByVenueId(string venueId);
        //预约管理
        Order GetByUserId(string userId);
    }
}
