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

        public bool Update(Order Order)
        {
           
            //Level l = IService.GetById(level.Id);
            //l.LevelName = level.LevelName;
            //l.LevelSort = level.LevelSort;
            return IService.Update(Order);

        }
    }
}
