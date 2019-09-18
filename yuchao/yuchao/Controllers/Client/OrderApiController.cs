using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Client;
using yuchao.Entity;
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

        [HttpPost()]
        public JsonResult CreateOrder([FromBody]JObject values) {

            Order order = bll.CreateOrder(values);


            return Json(new ApiResult()
            {
                Status = order == null ? 500 : 200,
                Error = order == null ? "创建订单失败" :"Success",
                Obj = bll.CreateOrder(values)
            });
        }
    }
}