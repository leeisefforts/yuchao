using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Admin;
using yuchao.Entity;

namespace yuchao.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/[controller]")]
    [ProducesResponseType(typeof(RefereeApply), 200)]
    [ApiController]
    public class RefereeApplyController : Controller
    {
        private RefereeApplyBLL bll = new RefereeApplyBLL();

        /// <summary>
        /// 根据UserId获取单条审核数据
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            return Json(bll.GetById(id));
        }

        [HttpPost("{id}")]
        public JsonResult ApplyById(int id) {
            return Json("");
        }
    }


    [Route("api/admin/[controller]")]
    public class TextController : Controller {
        [HttpGet]
        public JsonResult Get() {
            return Json("Success");
        }
    }
}