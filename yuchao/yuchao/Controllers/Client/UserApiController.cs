using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Client;
using yuchao.Model;
using yuchao.Model.Extends;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [ApiController]
    public class UserApiController : Controller
    {
        private UserApiBLL bll = new UserApiBLL();

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
    }
}