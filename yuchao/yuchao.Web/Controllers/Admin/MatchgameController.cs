﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Admin;
using yuchao.Model;

namespace yuchao.Web.Controllers.Admin
{
    [Route("api/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class MatchgameController : Controller
    {
        private MatchgameBLL bll = new MatchgameBLL();

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
    }
}