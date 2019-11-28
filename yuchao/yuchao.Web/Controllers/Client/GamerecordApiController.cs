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
using yuchao.Model.Extends;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class GamerecordApiController : Controller
    {
        private GamerecordApiBLL bll = new GamerecordApiBLL();
        private GamerecordBLL bll2 = new GamerecordBLL();

        [HttpGet("{venueId}")]
        public JsonResult GetGamerecordInfo(string venueId)
        {
            GamerecordReExtends gamerecord = bll.GetGamerecordInfoByVenueId(venueId);

            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = gamerecord
            });
        }

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

        [HttpPost("{openId}")]
        public JsonResult GameCreate(string openId , [FromBody]JObject values) {

            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.CreateGame(openId, values)
            });
        }

        [HttpPost("team/{openId}")]
        public JsonResult TeamGameCreate(string openId, [FromBody]JObject values)
        {

            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.CreateGame(openId, values)
            });
        }
    }

    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class RefereeGamerecordApiController : Controller
    {
        private GamerecordApiBLL bll = new GamerecordApiBLL();
        private GamerecordBLL bll2 = new GamerecordBLL();

        [HttpGet]
        public JsonResult GetGamerecordInfo()
        {
            List<GamerecordReExtends> list = bll.GetGamerecordInfoByRe();

            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = list
            });
        }

        [HttpGet("byre/{id}/{status}")]
        public JsonResult GetGamerecordByRe(int id, int status)
        {
            List<GamerecordReExtends> list = bll.GetGameByReId(id, status);

            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = list
            });
        }


        [HttpPost("addReferee")]
        public JsonResult AddReferee([FromBody]JObject values)
        {
            int id = Convert.ToInt32(values["id"]);
            int rid = Convert.ToInt32(values["rid"]);
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = bll.SetReferee(id, rid)
            });
        }

        [HttpPost("initResult")]
        public JsonResult initResult()
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = bll.InitResult()
            }); ;
        }


        [HttpPost("setResult")]
        public JsonResult SetResult([FromBody]JObject values)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = bll.SetResult(values)
            }); ;
        }

        [HttpPost("setGameOver")]
        public JsonResult setGameOver([FromBody]JObject values)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = bll.SetGameOver(values)
            });
        }

        [HttpGet("gameDetailList/{id}")]
        public JsonResult GameDetailList(int id)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GameDetailList(id)
            }); ;
        }
        
    }
}