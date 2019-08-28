using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public JsonResult ApplyById([FromBody] string values) {
            RefereeApply obj = JsonConvert.DeserializeObject<RefereeApply>(values);
            
            return Json("");
        }
    }

    internal class RefereeApplyBLL
    {
        internal object GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    internal class RefereeApply
    {
    }

    [Route("api/admin/[controller]")]
    public class TextController : Controller {
        [HttpGet]
        public JsonResult Get() {
            return Json("Success");
        }
    }
}