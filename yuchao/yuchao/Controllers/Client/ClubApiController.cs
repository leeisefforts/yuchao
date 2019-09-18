using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Business.Client;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Client
{ 
    /// <summary>
    /// 创建俱乐部
    /// </summary>
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ClubApiController : Controller
    {
        
        private ClubBLL bll = new ClubBLL();

        private ClubApiBLL cbll = new ClubApiBLL();

        // POST api/<controller>
        [HttpPost]
        public JsonResult Add(int id, [FromBody]JObject values)
        {
            Club obj = new Club()
            {
                ClubArea = values["clubArea"].ToString(),
                ClubCity = values["clubCity"].ToString(),
                ClubDesc = values["clubDesc"].ToString(),
                ClubLogo = values["clubLogo"].ToString(),
                ClubName = values["clubName"].ToString(),
                Status = 1,
                CreateTime = DateTime.Now
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

        [HttpPost]
        public JsonResult GetList([FromBody]JObject values) {


            List<Club> result = cbll.GetList(values["keyword"].ToString());
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });
        }
    }
}