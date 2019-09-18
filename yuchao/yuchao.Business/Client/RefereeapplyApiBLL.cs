using System;
using System.Collections.Generic;
using System.Text;
using yuchao.Entity;
using yuchao.IService;

namespace yuchao.Business.Client
{
    //申请裁判
   public class RefereeapplyApiBLL
    {
        private IRefereeApply IService = new Service.RefereeApplyService();

        public bool Insert(RefereeApply entity)
        {
            return IService.Add(entity);
        }
    }
}
