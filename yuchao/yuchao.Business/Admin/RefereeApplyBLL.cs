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


        public bool Update(RefereeApply refereeApply)
        {
            RefereeApply refereeApply1 = IService.GetById(refereeApply.Id);
            refereeApply1.ApplyDate = refereeApply.ApplyDate;
            refereeApply1.ApplyResult = refereeApply.ApplyResult;
            refereeApply1.ApplyUserId = refereeApply.ApplyUserId;

            return IService.Update(refereeApply);
        }

        public object DeleteById(int id)
        {

            return IService.Dels(id);
        }
    }
}
