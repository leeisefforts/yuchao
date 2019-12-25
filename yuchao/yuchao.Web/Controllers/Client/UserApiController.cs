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
using yuchao.Service;

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

    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class UserBindController : Controller
    {
        // POST api/<controller>
        [HttpGet("{code}")]
        public JsonResult GetOpenId(string code)
        {
            string url = "https://api.weixin.qq.com/sns/jscode2session?appid=wx78eab72a6ea9581d&secret=2a01de89252d7b4f2c23434ecbe5d862&js_code=" + code + "&grant_type=authorization_code";
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = BasicService.GetOpenId(url)
            });
        }

        [HttpPost]
        public JsonResult GetCode([FromBody]JObject values) {

            int code = BasicService.GetInt();
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = DxService.SendMsg(code, values["phone"].ToString(), values["openId"].ToString())
            });

        }

        [HttpPost("{code}")]
        public JsonResult GetCode(int code, [FromBody]JObject values)
        {

            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = DxService.ValidCode(code, values["openId"].ToString(), values["phone"].ToString())
            });

        }

        [HttpPost("setMsg/{openId}")]
        public JsonResult UpdateMSG(string openId, [FromBody]JObject values) {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = BasicService.SetMsg(openId, values["name"].ToString(), values["birthday"].ToString(),Convert.ToInt32( values["gender"]), values["phone"].ToString())
            });

            
        }
    }
}