using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yuchao.Controllers.Admin.Club
{
    /// <summary>
    /// 俱乐部后台接口
    /// </summary>
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ClubController : Controller
    {
        private ClubBLL bll = new ClubBLL();
        /// <summary>
        /// 获取俱乐部列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get() {
            return Json("Success");
        }
        //根据Id查
        [HttpGet("{Id}")]
        public JsonResult GetById(int Id)
        {
            return Json(bll.GetById(Id));
        }
        //[HttpPost]
        //public JsonResult Post([FromBody]string Json)
        //{

        //    return Json("Success");
        //}
        [HttpPost("Add")]
        public JsonResult PostAdd([FromBody]string values)
        {
            JObject obj = JsonConvert.DeserializeObject<JObject>(values);
            return Json("");
        }
        [HttpPut("{id}")]
        public JsonResult Update()
        {
            
            return Json("values");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete()
        {
            return Json("");
        }

        internal class ClubBLL
        {
            public ClubBLL()
            {
            }

            internal object GetById(/*int id*/int id)
            {
                throw new NotImplementedException();
            }
            internal class Club
            {
            }

            [Route("api/admin/[controller]")]
            public class TextController : Controller
            {
                [HttpGet]
                public JsonResult Get()
                {
                    return Json("Success");
                }
            }
        }
    }
}
