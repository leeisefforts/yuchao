using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Admin;

namespace yuchao.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : Controller
    {
        private LevelBLL bll = new LevelBLL();

        [HttpGet]
        public JsonResult GetAll() {
            return Json(bll.GetAll());
        }
    }
}