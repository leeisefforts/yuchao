using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
   public class OrderBLL
    {
        private IOrder IService = new Service.OrderService();
        private object order;

        public List<Order> GetAll()
        {
            return IService.GetAll();
        }

        public bool Insert(Order Order)
        {
            return IService.Insert(Order);
        }

        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }

        public bool Update(Order order)
        {

            Order order1 = IService.GetById(order.Id);
            order1.CreateTime = order.CreateTime;
            order1.GameTime = order.GameTime;
            order1.Money = order.Money;
            order1.OrderSn = order.OrderSn;
            order1.OrderType = order.OrderType;
            order1.PayStatus = order.PayStatus;
            order1.PayTime = order.PayTime;
            order1.Status = order.Status;
            order1.VenueId = order.VenueId;

            return IService.Update(order);

        }
    }
}
