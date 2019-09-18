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
using yuchao.Model.Extends;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class UserApiController : Controller
    {
        private UserApiBLL bll = new UserApiBLL();


        private UserBLL bull = new UserBLL();


        [HttpGet("{openId}")]
        public JsonResult GetUserInfo(string openId) {

            UserExtends user = bll.GetUserInfoByOpenId(openId);

            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = user
            });
        }


        // POST api/<controller>
        [HttpPost("{openId}")]
        public JsonResult Post(string openId, [FromBody]JObject values)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = bll.OpsUserInfo(openId, values)
            }); ; ;
        }
    }


    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class UserPhoneController : Controller
    {
        private UserApiBLL bll = new UserApiBLL();


        private UserBLL bull = new UserBLL();

        // POST api/<controller>
        [HttpPost("{openId}")]
        public JsonResult Post(string openId, [FromBody]JObject values)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = bll.SaveTel(openId, values["tel"].ToString())
            }); ; ;
        }
    }
}