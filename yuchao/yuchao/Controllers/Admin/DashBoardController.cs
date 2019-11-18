using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yuchao.Model;

namespace yuchao.Web.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class DashBoardController: Controller
    {
        [HttpPost]
        public JsonResult GetData([FromBody]JObject values) {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = ""
            });
        }
    }
}
