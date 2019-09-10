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
    public class GamerecordController : Controller
    {
        private GamerecordBLL bll = new GamerecordBLL();

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetAll()
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
            bool suc = bll.Insert(new Gamerecord()
            {
                WinId = Convert.ToInt32(values["levelSort"]),
                Statue = Convert.ToInt32(values["levelSort"]),
                RefereeId = Convert.ToInt32(values["levelSort"]),
                LoseId = Convert.ToInt32(values["levelSort"]),
                IsTeamGame = Convert.ToInt32(values["levelSort"]),
                GameTime = Convert.ToDateTime(values["levelSort"]),
                CreateTime = Convert.ToDateTime(values["levelSort"])
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
                Obj = bll.Update(new Gamerecord()
                {
                    Id = id,
                    WinId = Convert.ToInt32(values["levelSort"]),
                    Statue = Convert.ToInt32(values["levelSort"]),
                    RefereeId = Convert.ToInt32(values["levelSort"]),
                    LoseId = Convert.ToInt32(values["levelSort"]),
                    IsTeamGame = Convert.ToInt32(values["levelSort"]),
                    GameTime = Convert.ToDateTime(values["levelSort"]),
                    CreateTime = Convert.ToDateTime(values["levelSort"])
                })
            };
            return Json(res);
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteById(int id)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.DeleteById(id)
            });
        }
    }
}