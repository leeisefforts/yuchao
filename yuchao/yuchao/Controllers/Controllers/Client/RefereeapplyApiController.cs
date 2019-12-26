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
        [HttpPost("{openId}")]
        public JsonResult Post(string openId, [FromBody]JObject values)
        {

            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = bll.ApplyRef(openId, values)
            });
        }
    }
}