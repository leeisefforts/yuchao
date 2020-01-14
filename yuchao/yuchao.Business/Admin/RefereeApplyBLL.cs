using Newtonsoft.Json.Linq;
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
        private IUser UService = new Service.UserServer();

        public RefereeApply GetById(int id)
        {
            return IService.Get(id);
        }

        public bool Insert(RefereeApply entity)
        {
            return IService.Add(entity);
        }


        public bool Update(RefereeApply refereeApply)
        {
            RefereeApply refereeApply1 = IService.Get(refereeApply.Id);
            refereeApply1.ApplyDate = refereeApply.ApplyDate;
            refereeApply1.ApplyResult = refereeApply.ApplyResult;
            refereeApply1.ApplyUserId = refereeApply.ApplyUserId;
            return IService.Update(refereeApply);
        }

        public object DeleteById(dynamic ids)
        {
            return IService.Dels(ids);
        }

        public bool ApplyRef(string openId, JObject values)
        {
            User user = UService.GetByOpenId(openId);
            user.IsApplyReferee = 1;
            UService.Update(user);
            RefereeApply entity = new RefereeApply()
            {
                OpenId = openId,
                ApplyDate = DateTime.Now,
                CreateTime = DateTime.Now,
                ApplyResult = 0,
                ApplyUserId = user.Id,
                Phone = Convert.ToInt32(values["phone"]),
                Name = values["name"].ToString()

            };
            return IService.Add(entity);
        }

        public List<RefereeApply> GetList() {
            return IService.GetAllByStatus();
        }


        public bool UpdateStatus(int id, int status)
        {
            return IService.UpdateStatus(id, status);
        }
        
    }
}
