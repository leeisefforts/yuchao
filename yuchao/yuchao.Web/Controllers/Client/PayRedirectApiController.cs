using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SqlSugar;
using yuchao.Entity;
using yuchao.Model;
using yuchao.Model.XML;
using yuchao.Service;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/xml")]
    [ApiController]
    public class PayRedirectApiController : Controller
    {
        public SimpleClient<PayResult> rdb = new SimpleClient<PayResult>(BaseDb.GetClient());
        [HttpPost]
        public JsonResult Get([FromBody]string values) {

            PayResult re = new PayResult() {
                CreateTime = DateTime.Now,
                PayResultXml = values
            };
            rdb.Insert(re);

            string xml = BasicService.Serialize<PayResultXml>(new PayResultXml() {
                return_code = "SUCCESS",
                return_msg = "OK"
            });
            return Json(xml);
        }
    }
}