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
    /// 实名认真
    /// </summary>
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class VerifieduserApiController : Controller
    {
        private VerifieduserBLL bll = new VerifieduserBLL();

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post(int id, [FromBody]JObject values)
        {
            Verifieduser obj = new Verifieduser()
            {
               
                UserId = Convert.ToInt32(values["userId"]),
                Card = values["card"].ToString(),
                CardImg1 = values["cardImg1"].ToString(),
                CardImg2 = values["cardImg2"].ToString()

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