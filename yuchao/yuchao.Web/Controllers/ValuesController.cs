using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using yuchao.Service;

namespace yuchao.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowCors")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            string cc = BasicService.InitQrCode("https://baidu.com");
            return Json("Success Job");
        }
    }
}
