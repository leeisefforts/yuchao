using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Client
{
    /// <summary>
    /// 申请裁判
    /// </summary>
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class RefereeapplyApiController : Controller
    {
        private RefereeApplyBLL bll = new RefereeApplyBLL();

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post(int id, [FromBody]JObject values)
        {
            RefereeApply obj = new RefereeApply()
            {
                ApplyUserId = Convert.ToInt32(values["applyUserId"]),
                ApplyResult = Convert.ToInt32(values["applyResult"]),
                ApplyDate = Convert.ToDateTime(values["applyDate"])
            };
            bool result = false;
            if (id != 0)
            {
                obj.Id = id;
                result = bll.Update(obj);
            }
            else
            {
                result = bll.Insert(obj);
            }
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });
        }
    }
}