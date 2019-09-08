using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model;

namespace yuchao.Service
{
   public class OrderService:BaseDb,IOrder
    {
        public SimpleClient<Order> rdb = new SimpleClient<Order>(BaseDb.GetClient());

        public List<Order> GetAll()
        {
            return rdb.GetList();
        }

        public bool Insert(Order order)
        {
            return rdb.Insert(order);
        }

        public Order GetById(object id)
        {
            return rdb.GetById(id);
        }

        public bool DeleteById(int id)
        {
            return rdb.DeleteById(id);
        }

        public bool Update(Order order)
        {
            return rdb.Update(order);
        }
        public Order GetByVenueId(string venueId)
        {
            return rdb.GetSingle(p => p.VenueId.Equals(venueId));
        }

        public Order GetById(int id)
        {
            return rdb.GetById(id);
        }
        //预约管理
        public Order GetByUserId(string userId)
        {
            return rdb.GetSingle(p => p.UserId.Equals(userId));
        }
    }
}
