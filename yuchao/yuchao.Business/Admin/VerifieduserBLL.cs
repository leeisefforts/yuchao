using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
   public class VerifieduserBLL
    {
        private IVerifieduser IService = new Service.VerifieduserServer();
        //查询所有
        public List<Verifieduser> GetAll()
        {
            return IService.GetAll();
        }
        //增加
        public bool Insert(Verifieduser verifieduser)
        {
            return IService.Insert(verifieduser);
        }
        //删除
        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }
        //修改
        public bool Update(Verifieduser verifieduser)
        {
            Verifieduser verifieduser1 = IService.GetById(verifieduser.Id);
            verifieduser1.Card = verifieduser.Card;
            verifieduser1.CardImg1 = verifieduser.CardImg1;
            verifieduser1.CardImg2 = verifieduser.CardImg2;
            verifieduser1.UserId = verifieduser.UserId;
            return IService.Update(verifieduser);
        }     
    }
}
