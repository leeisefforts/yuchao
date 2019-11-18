using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Model;
using yuchao.Business.Admin;

namespace yuchao.Web.Controllers.Admin
{
    [Route("api/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    //场馆消费一览
    public class VenveConsumeController : Controller
    {
        private VenveConsumeBLL bll = new VenveConsumeBLL();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult GetAll()
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetAll()
            });
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