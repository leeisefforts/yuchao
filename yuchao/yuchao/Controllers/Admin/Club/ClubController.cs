using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yuchao.Controllers.Admin.Club
{
    /// <summary>
    /// 俱乐部后台接口
    /// </summary>
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [ApiController]
    public class ClubController: Controller
    {
        /// <summary>
        /// 获取俱乐部列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get() {
            return Json("Success");
        }

        [HttpPost]
        public JsonResult Post([FromBody]string values) {
            return Json("Success");
        }
    }
}
