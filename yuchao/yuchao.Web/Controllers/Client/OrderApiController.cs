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
using yuchao.Service;

namespace yuchao.Controllers.Client
{
    [Route("api/client/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class OrderApiController : Controller
    {
        private OrderApiBLL bll = new OrderApiBLL();

        [HttpGet("{openId}")]
        public JsonResult GetOrderInfo(string openId)
        {
            OrderExtends user = bll.GetByOpenId(openId);
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = user
            });
        }

        [HttpGet("venueOrder/{openId}")]
        public JsonResult GetvenueOrderInfo(string openId)
        {
            OrderExtends user = bll.GetByOpenId(openId);
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = user
            });
        }

        [HttpPost("orderdetail/{openId}")]
        public JsonResult OrderDetail(string openId, [FromBody]JObject values)
        {
            int sid = Convert.ToInt32(values["sId"]);
            int isGame = Convert.ToInt32(values["isGame"]);
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetOrderDetail(openId, isGame, sid)
            });
        }

        [HttpPost("refund/{openId}")]
        public JsonResult RefundPay(string openId, [FromBody]JObject values)
        {
            string orderSn =  values["orderSn"].ToString();
            return Json(new ApiResult()
            {
                Status = 200,
                Error = "Success",
                Obj = BasicService.RefundPay(orderSn)
            });
        }
    }
}