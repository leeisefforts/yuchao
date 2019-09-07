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

        Order GetByVenueId(string venueId);
    }
}
