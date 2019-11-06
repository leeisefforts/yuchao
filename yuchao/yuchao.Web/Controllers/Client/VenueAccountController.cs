using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yuchao.Business.Client;
using yuchao.Model;

namespace yuchao.Web.Controllers.Client
{

    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class VenueAccountController : Controller
    {

        private VenueAccountBLL bll = new VenueAccountBLL();
        [HttpPost]
        public JsonResult Login([FromBody]JObject values)
        { 
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Login(values["loginName"].ToString(),values["loginPwd"].ToString())
            });
        }

        [HttpPost("{siteId}")]
        public JsonResult SetSite(int siteId, [FromBody]JObject values) {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.SetSite(siteId, values)
            });

        }

        [HttpGet("{id}")]
        public JsonResult GetData(int id) {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetPage(id)
            });
        }
    }
}
