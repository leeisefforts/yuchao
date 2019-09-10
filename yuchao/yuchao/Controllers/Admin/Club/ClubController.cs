using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Admin
{
    /// <summary>
    /// 俱乐部后台接口
    /// </summary>
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ClubController : Controller
    {
        private ClubBLL bll = new ClubBLL();
        /// <summary>
        /// 获取俱乐部列表
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
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
        [HttpPost]
        public JsonResult Post(int id, [FromBody]JObject values)
        {
            Club obj = new Club()
            {
                ClubArea = values["clubArea"].ToString(),
                ClubCity = values["clubCity"].ToString(),
                ClubDesc = values["clubDesc"].ToString(),
                ClubLogo = values["clubLogo"].ToString(),
                ClubName = values["clubName"].ToString(),
                Status = Convert.ToInt32(values["status"]),
                CreateTime = Convert.ToDateTime(values["createTime"])
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
        public JsonResult Update(int id, [FromBody]JObject values)
        {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Update(new Club() {
                    Id = id,
                    ClubArea = values["clubArea"].ToString(),
                    ClubCity = values["clubCity"].ToString(),
                    ClubDesc = values["clubDesc"].ToString(),
                    ClubLogo = values["clubLogo"].ToString(),
                    ClubName = values["clubName"].ToString(),
                    CreateTime = Convert.ToDateTime(values["createTime"]),
                    Status = Convert.ToInt32(values["status"])
                })
            };
            return Json(res);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public JsonResult DeleteById(dynamic[] ids)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.DeleteById(ids)
            });
        }
    }
}
