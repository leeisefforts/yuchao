﻿using System;
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
    //赛事一览
    public class GamerecordController : Controller
    {
        private GamerecordBLL bll = new GamerecordBLL();

        [HttpGet("{openId}")]
        public JsonResult GetAll(string openId)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetAll(openId)
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
                WinId = values["winId"].ToString(),
                Status = Convert.ToInt32(values["levelSort"]),
                RefereeId = Convert.ToInt32(values["levelSort"]),
                LoseId = values["losId"].ToString(),
                IsTeamGame = Convert.ToInt32(values["levelSort"]),
                GameTime = values["levelSort"].ToString(),
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
                    WinId = values["levelSort"].ToString(),
                    Status = Convert.ToInt32(values["levelSort"]),
                    RefereeId = Convert.ToInt32(values["levelSort"]),
                    LoseId = values["levelSort"].ToString(),
                    IsTeamGame = Convert.ToInt32(values["levelSort"]),
                    GameTime = values["levelSort"].ToString(),
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