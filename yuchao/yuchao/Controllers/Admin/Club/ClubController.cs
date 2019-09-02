using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Admin
{
    /// <summary>
    /// 俱乐部后台接口
    /// </summary>
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ClubController : Controller
    {
        private ClubBLL bll = new ClubBLL();


        /// <summary>
        /// 获取俱乐部列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get() {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Get()
            });
        }

        [HttpGet]
        public JsonResult Insert([FromBody]JObject values)
        {

            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"

            };
            bool suc = bll.Insert(new Entity.Club() { ClubName = values["ClubName"].ToString(), ClubDesc = values["ClubDesc"].ToString(), ClubLogo = values["ClubLogo"].ToString(), ClubCity = values["ClubCity"].ToString(), ClubArea = values["ClubArea"].ToString() });
            if (suc) res.Obj = true;
            else
            {
                res.Status = -1;
                res.Obj = false;
            }

            return Json(res);
        }

        [HttpPost("Add")]
        public JsonResult PostAdd([FromBody]string values)
        {
            Object obj = JsonConvert.DeserializeObject<JObject>(values);
            return Json("");
        }
        [HttpPut("{id}")]
        public JsonResult Update(int id,[FromBody]string values)
        {

            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"

            };
            bool suc = bll.Update(new Entity.Club() { Id = id, ClubName = "ClubName", ClubDesc = "ClubDesc", ClubLogo ="ClubLogo" });
            if (suc) res.Obj = true;
            else
            {
                res.Status = -1;
                res.Obj = false;
            }

            return Json(res);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete()
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Delete()
            });
        }

        internal class ClubBLL
        {
            public ClubBLL()
            {
            }

            internal object GetById(/*int id*/int id)
            {
                throw new NotImplementedException();
            }

            internal object Get()
            {
                throw new NotImplementedException();
            }

            internal bool Insert(Club club)
            {
                throw new NotImplementedException();
            }

            internal bool Insert(Entity.Club club)
            {
                throw new NotImplementedException();
            }

            internal object Delete()
            {
                throw new NotImplementedException();
            }

            internal bool Update(Entity.Club club)
            {
                throw new NotImplementedException();
            }

            internal bool Update(string v)
            {
                throw new NotImplementedException();
            }

            internal class Club
            {
            }

            [Route("api/admin/[controller]")]
            public class TextController : Controller
            {
                [HttpGet]
                public JsonResult Get()
                {
                    return Json("Success");
                }
            }
        }
    }
}
