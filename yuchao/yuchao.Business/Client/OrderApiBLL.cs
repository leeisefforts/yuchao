using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.Model.Extends;
using yuchao.Service;

namespace yuchao.Business.Client
{
   public class OrderApiBLL
    {
        //订单
        private OrderService IService = new OrderService();
        private VenueService LService = new VenueService();


        public OrderExtends GetOrderInfoByVenueId(string venueId)
        {
            // 根据VenueId获取Order
            Order order = IService.GetByVenueId(venueId);
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
                orderInfo.VenueName = LService.GetById(order.VenueId).VenueName;
                orderInfo.Score = LService.GetById(order.VenueId).Score;
                orderInfo.VenueAddress = LService.GetById(order.VenueId).VenueAddress;
                orderInfo.VenueImg = LService.GetById(order.VenueId).VenueImg;
                orderInfo.AvePrice = LService.GetById(order.VenueId).AvePrice;

            }
            return orderInfo;
        }

    }
}
