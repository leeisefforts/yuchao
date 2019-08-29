using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class LevelController : Controller
    {
        private LevelBLL bll = new LevelBLL();

        [HttpGet]
        public JsonResult GetAll() {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetAll()
            });
        }

        [HttpPost]
        public JsonResult Insert([FromBody]JObject values) {

            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"
         
            };
            bool suc = bll.Insert(new Level() { LevelName= values["levelName"].ToString(), LevelSort=Convert.ToInt32( values["levelSort"])});
            if (suc) res.Obj = true;
            else
            {
                res.Status = -1;
                res.Obj = false;
            }

            return Json(res);
        }

        [HttpPost("{id}")]
        public JsonResult Update(int id, [FromBody]JObject values) {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"

            };
            bool suc = bll.Update(new Level() {Id=id ,LevelName = values["levelName"].ToString(), LevelSort = Convert.ToInt32(values["levelSort"]) });
            if (suc) res.Obj = true;
            else
            {
                res.Status = -1;
                res.Obj = false;
            }

            return Json(res);
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteById(int id) {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.DeleteById(id)
            });
        }
    }
}