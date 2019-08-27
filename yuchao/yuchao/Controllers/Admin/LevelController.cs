using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Admin
{
    [Route("api/[controller]")]
    [EnableCors("AllowCors")]
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
        public JsonResult Insert([FromBody]string values) {
            Level obj = JsonConvert.DeserializeObject<Level>(values);


            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"
         
            };
            bool suc = bll.Insert(obj);
            if (suc) res.Obj = true;
            else {
                res.Status = -1;
                res.Obj = false;
            }

            return Json(res);
        }

        [HttpDelete]
        public JsonResult DeleteById(int id) {
            return Json(new ApiResult {
                Status = 200,
                Error = "Success",
                Obj = "Success"
            });
        }
    }
}