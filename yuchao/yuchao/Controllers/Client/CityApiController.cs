using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yuchao.Model;
using yuchao.Service;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class CityApiController : Controller
    {
        [HttpGet]
        public JsonResult GetAllPro() {

            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = BasicService.GetAllPro()
            });
        }

        [HttpGet("{pid}")]
        public JsonResult GetAllPro(int pid)
        {

            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = BasicService.GetCity(pid)
            });
        }
    }
}
