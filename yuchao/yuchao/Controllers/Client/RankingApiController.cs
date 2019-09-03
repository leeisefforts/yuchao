using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Client
{
    /// <summary>
    /// 比赛排名
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class RankingApiController : Controller
    {
        private RankingBLL bll = new RankingBLL();
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult Insert(Ranking entity)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Insert(entity)
            });
        }
    }
}