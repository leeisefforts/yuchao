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
        [HttpPost("{id}")]
        public JsonResult Post(int id, [FromBody]JObject values)
        {
            User obj = new User()
            {
                NickName = values["nickName"].ToString(),
                Language = values["language"].ToString(),
                Gender = Convert.ToInt32(values["gender"]),
                AvatarUrl = values["avatarUrl"].ToString(),
                Country = values["country"].ToString(),
                City = values["city"].ToString(),
                Province = values["province"].ToString()
            };
            bool result = false;
            if (id != 0)
            {
                obj.Id = id;
                result = bull.Update(obj);
            }
            else
            {
                result = bull.Insert(obj);
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