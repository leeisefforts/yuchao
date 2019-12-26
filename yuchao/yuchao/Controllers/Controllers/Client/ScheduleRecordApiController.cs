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
using yuchao.Model;

namespace yuchao.Controllers.Client
{
    /// <summary>
    /// 场地信息
    /// </summary>
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ScheduleRecordApiController : Controller
    {
        private ScheduledRecordApiBLL bll = new ScheduledRecordApiBLL();

        [HttpGet("{venueId}/{date}")]
        public JsonResult GetList(int venueId, string date)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetList(venueId, date)
            });
        }

        [HttpGet("list/{openId}/{isGame}")]
        public JsonResult GetList2(string openId, int isGame)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetListByOpenId(openId, isGame)
            });
        }


        [HttpPost("{openId}")]
        public JsonResult CreateSc(string openId,[FromBody]JObject values)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.CreateSc(openId, values)
            });
        }

        [HttpPost("paysuccess/{sid}")]
        public JsonResult Paysuccess(int sid, [FromBody]JObject values)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.SetSStatus(sid)
            });
        }
    }
}