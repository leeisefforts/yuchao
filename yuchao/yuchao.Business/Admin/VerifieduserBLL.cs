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

        public List<Verifieduser> GetAll()
        {
            return IService.GetAll();
        }

        public bool Insert(Verifieduser verifieduser)
        {
            return IService.Insert(verifieduser);
        }

        public bool DeleteById(int id)
        {
            return IService.DeleteById(id);
        }

        public bool Update(Verifieduser verifieduser)
        {

            return IService.Update(verifieduser);
        }
    }
}
