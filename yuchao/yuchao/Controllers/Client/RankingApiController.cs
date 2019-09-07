using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Admin;
using yuchao.Business.Client;
using yuchao.Entity;
using yuchao.Model;
using yuchao.Model.Extends;

namespace yuchao.Controllers.Client
{
    /// <summary>
    /// 比赛排名
    /// </summary>
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class RankingApiController : Controller
    {
        private RankingApiBLL bll = new RankingApiBLL();
        // GET api/<controller>/5
        [HttpGet("{userId}")]
        public JsonResult GetRankingInfo(string userId)
        {
            RankingExtends ranking = bll.GetRankingInfoByUserId(userId);
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = ranking
            });
        }
    }
}