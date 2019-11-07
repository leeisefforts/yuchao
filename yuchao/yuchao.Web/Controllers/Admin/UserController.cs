using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yuchao.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private UserBLL bll = new UserBLL();

        // GET: api/<controller>
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetById(id)
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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]JObject values)
        {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "success",
                Obj = bll.Update(new User
                {
                    AvatarUrl = values["avatarUrl"].ToString(),
                    City = values["city"].ToString(),
                    Country = values["country"].ToString(),
                    Gender = Convert.ToInt32(values["gender"]),
                    Language = values["language"].ToString(),
                    NickName = values["nickName"].ToString(),
                     Province=values["province"].ToString()
                })
            };
             return Json(res);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public JsonResult DeleteByIds(dynamic[] ids)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.DeleteByIds(ids)
            });
        }
    }
}
