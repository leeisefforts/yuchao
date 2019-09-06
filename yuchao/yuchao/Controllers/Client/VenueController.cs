using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Client;
using yuchao.Entity;
using yuchao.Model;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [ApiController]
    public class VenueController : Controller
    {
        private VenueApiBLL bll = new VenueApiBLL();

        [HttpGet]
        public JsonResult GetList() {

            List<Venue> list = bll.GetAll();


            return Json(new ApiResult() {
                Status = 200,
                Error = string.Empty,
                Obj  = list
            });
        }
    }
}