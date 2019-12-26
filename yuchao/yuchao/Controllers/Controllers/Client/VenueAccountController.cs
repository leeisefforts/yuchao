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

        [HttpPost("getdata/{id}")]
        public JsonResult GetData(int id, [FromBody]JObject values) {
            int page = Convert.ToInt32(values["page"]);
            int size = Convert.ToInt32(values["size"]);
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetPage(id, page, size)
            });
        }
    }

    [Route("api/client/set/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class VenueSetController : Controller
    {

        private VenueAccountBLL bll = new VenueAccountBLL();

        [HttpPost("{id}")]
        public JsonResult Login(int id,[FromBody]JObject values)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.SetAn(id, values)
            });
        }
    }


    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ReferAccountController : Controller
    {

        private VenueAccountBLL bll = new VenueAccountBLL();

        [HttpPost]
        public JsonResult Login([FromBody]JObject values)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Login2(values["loginName"].ToString(), values["loginPwd"].ToString())
            });
        }

    }
}
