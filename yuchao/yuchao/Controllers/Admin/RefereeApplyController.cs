using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [ProducesResponseType(typeof(RefereeApply), 200)]
    [ApiController]
    public class RefereeApplyController : Controller
    {
        private RefereeApplyBLL bll = new RefereeApplyBLL();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post(int id, [FromBody]JObject values)
        {
            RefereeApply obj = new RefereeApply()
            {
                 
                 ApplyUserId= Convert.ToInt32(values["applyUserId"]),
                 ApplyResult = Convert.ToInt32(values["applyResult"]),
                 ApplyDate =Convert.ToDateTime(values["applyDate"])
            };
            bool result = false;
            if (id != 0)
            {
                obj.Id = id;
                result = bll.Update(obj);
            }
            else
            {
                result = bll.Insert(obj);
            }


            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });


        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
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