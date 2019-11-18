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
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Client
{ 
    /// <summary>
    /// 创建俱乐部
    /// </summary>
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ClubApiController : Controller
    {       
        private ClubBLL bll = new ClubBLL();

        private ClubApiBLL cbll = new ClubApiBLL();
        // POST api/<controller>
        [HttpPost("create/{openId}")]
        public JsonResult Add(string openId, [FromBody]JObject values)
        {
            Club obj = new Club()
            {
                ClubArea = values["clubArea"].ToString(),
                ClubCity = values["clubCity"].ToString(),
                ClubDesc = values["clubDesc"].ToString(),
                ClubLogo = values["clubLogo"].ToString(),
                ClubName = values["clubName"].ToString(),
                Status = 1,
                CreateTime = DateTime.Now,
                OpenId = openId
            };
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = bll.Insert(HttpContext.Request.Host.ToString(),obj)
            });
        }

        [HttpPost]
        public JsonResult GetList([FromBody]JObject values) {
            List<Club> result = cbll.GetList(values["keyword"].ToString());
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });
        }

        [HttpPost("{id}")]
        public JsonResult GetById(int id)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = cbll.GetById(id)
            });
        }

        [HttpGet("{openId}")]
        public JsonResult GetByOpenId(string openId)
        {
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = cbll.GetByOpenId(openId)
            });
        }
    }


    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ClubApplyApiController : Controller
    {
        private ClubBLL bll = new ClubBLL();

        private ClubApiBLL cbll = new ClubApiBLL();
        // POST api/<controller>
        [HttpPost("{openId}")]
        public JsonResult Add(string openId, [FromBody]JObject values)
        {
            Club obj = new Club()
            {
                ClubArea = values["clubArea"].ToString(),
                ClubCity = values["clubCity"].ToString(),
                ClubDesc = values["clubDesc"].ToString(),
                ClubLogo = values["clubLogo"].ToString(),
                ClubName = values["clubName"].ToString(),
                Status = 1,
                CreateTime = DateTime.Now,
                OpenId = openId
            };

            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = bll.Insert(Request.Path.Value, obj)
            });
        }

        [HttpPost]
        public JsonResult Apply([FromBody]JObject values)
        {

            int clubid = Convert.ToInt32(values["clubId"]);
            string  openId = values["openId"].ToString();

            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = cbll.Apply(clubid, openId)
            });
        }


        [HttpPost("exit")]
        public JsonResult Exit([FromBody]JObject values)
        {

            int clubid = Convert.ToInt32(values["clubId"]);
            string openId = values["openId"].ToString();

            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = cbll.Exit(clubid, openId)
            });
        }

    }

    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class ClubMsgApiController : Controller
    {
        private ClubBLL bll = new ClubBLL();

        private ClubApiBLL cbll = new ClubApiBLL();

        // POST api/<controller>
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {

            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = bll.GetClubUser(id)
            });
        }
    }
}