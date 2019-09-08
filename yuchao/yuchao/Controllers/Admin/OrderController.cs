using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;
using yuchao.Model.Extends;

namespace yuchao.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class OrderController : Controller
    { 
        private OrderBLL bll = new OrderBLL();

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetAll()
            });
        }
        //预约管理
        [HttpGet("{userId}")]
        public JsonResult GetOrderInfo(string userId)
        {
            OrderExtends ranking = bll.GetOrderInfoByUserId(userId);
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = ranking
            });
        }

        [HttpPost]
        public JsonResult Insert([FromBody]JObject values)
        {

            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success"
            };
            bool suc = bll.Insert(new Order()
            {
                CreateTime = Convert.ToDateTime(values["createTime"]),
                Money = Convert.ToDecimal(values["money"]),
                OrderSn = values["orderSn"].ToString(),
                OrderType = Convert.ToInt32(values["orderType"]),
                PayStatus = Convert.ToInt32(values["payStatus"]),
                PayTime = Convert.ToDateTime(values["payTime"]),
                Status = Convert.ToInt32(values["status"]),
                VenueId = Convert.ToInt32(values["venueId"])

            });
            if (suc) res.Obj = true;
            else
            {
                res.Status = -1;
                res.Obj = false;
            }
            return Json(res);
        }

        [HttpPut]
        public JsonResult Update(int id, [FromBody]JObject values)
        {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.Update(new Order()
                {
                    Id = id,
                    CreateTime = Convert.ToDateTime(values["createTime"]),
                    Money = Convert.ToDecimal(values["money"]),
                    OrderSn = values["orderSn"].ToString(),
                    OrderType = Convert.ToInt32(values["orderType"]),
                    PayStatus = Convert.ToInt32(values["payStatus"]),
                    PayTime = Convert.ToDateTime(values["payTime"]),
                    Status = Convert.ToInt32(values["status"]),
                    VenueId = Convert.ToInt32(values["venueId"])
                })
            };
            return Json(res);
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteById(int id)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.DeleteById(id)
            });
        }
    }
}