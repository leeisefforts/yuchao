using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuchao.Business.Client;
using yuchao.Model;
using yuchao.Model.Extends;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class GamerecordApiController : Controller
    {
        private GamerecordApiBLL bll = new GamerecordApiBLL();

        [HttpGet("{venueId}")]
        public JsonResult GetGamerecordInfo(string venueId)
        {

            GamerecordExtends gamerecord = bll.GetGamerecordInfoByVenueId(venueId);

            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = gamerecord
            });
        }
    }
}