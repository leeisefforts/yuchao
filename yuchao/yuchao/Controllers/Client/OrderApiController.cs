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
    public class OrderApiController : Controller
    {
        private OrderApiBLL bll = new OrderApiBLL();

        [HttpGet("{VenueId}")]
        public JsonResult GetOrderInfo(string venueId)
        {

            OrderExtends user = bll.GetOrderInfoByVenueId(venueId);

            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = user
            });
        }
    }
}