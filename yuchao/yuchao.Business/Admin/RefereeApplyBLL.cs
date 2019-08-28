using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Admin
{
    public class RefereeApplyBLL
    {
        private IRefereeApply IService = new Service.RefereeApplyService();

        public RefereeApply GetById(int id) {
            return IService.Get(id);
        }

        public bool Insert(RefereeApply entity) {
            return IService.Add(entity);
        }
       
    }
}
