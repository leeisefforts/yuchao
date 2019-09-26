using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Admin
{
   public class OrderBLL
    {
        private IOrder IService = new Service.OrderService();

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
        //预约管理
        private UserServer LService = new UserServer();
        public OrderExtends GetOrderInfoByUserId(string userId)
        {
            // 根据userId获取Order
            Order order = IService.GetByUserId(userId);
            OrderExtends orderInfo = new OrderExtends();
            if (order != null)
            {
                orderInfo.Id = order.Id;
                orderInfo.CreateTime = order.CreateTime;
                orderInfo.GameTime = order.GameTime;
                orderInfo.Money = order.Money;
                orderInfo.OrderSn = order.OrderSn;
                orderInfo.OrderType = order.OrderType;
                orderInfo.PayStatus = order.PayStatus;
                orderInfo.PayTime = order.PayTime;
                orderInfo.Status = order.Status;
                orderInfo.VenueId = order.VenueId;
                orderInfo.UserId = order.UserId;


            }
            return orderInfo;
        }
    }
}
