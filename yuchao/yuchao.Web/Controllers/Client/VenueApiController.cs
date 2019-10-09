using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
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
    public class VenueApiController : Controller
    {
        private VenueBLL bll = new VenueBLL();

        // GET api/<controller>/5
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
    }


    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class SiteApiController : Controller
    {
        private VenueBLL bll = new VenueBLL();

        // GET api/<controller>/5
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
        [HttpGet("{venueId}")]
        public JsonResult GetSite(int venueId)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetSiteById(venueId)
            });
        }
    }
}