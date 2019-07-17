using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Admin;

namespace yuchao.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class RefereeApplyController : Controller
    {
        private RefereeApplyBLL bll = new RefereeApplyBLL();

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            return Json(bll.GetById(id));
        }
    }
}