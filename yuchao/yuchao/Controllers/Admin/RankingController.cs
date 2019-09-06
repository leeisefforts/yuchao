using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class RankingController : Controller
    {
        private RankingBLL bll = new RankingBLL();

        [HttpGet]
        public JsonResult GetById(int id)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetById(id)
            });
        }

        [HttpPost]
        public JsonResult Insert([FromBody]JObject values)
        {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"

            };
            bool suc = bll.Insert(new Ranking()
            {
                Rank = Convert.ToInt32(values["rank"]),
                UserId = Convert.ToInt32(values["userId"])
            });
            if (suc) res.Obj = true;
            else
            {
                res.Status = -1;
                res.Obj = false;
            }
            return Json(res);
        }

        [HttpPut]
        public JsonResult Update(int id, [FromBody]JObject values)
        {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Update(new Ranking()
                {
                    Id = id,
                    Rank = Convert.ToInt32(values["rank"]),
                    UserId = Convert.ToInt32(values["userId"])
                })
            };
            return Json(res);
        }

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