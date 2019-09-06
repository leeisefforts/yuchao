using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using yuchao.Business.Admin;
using yuchao.Entity;
using yuchao.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yuchao.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    public class VenueController : Controller
    {
        private VenueBLL bll = new VenueBLL();

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

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post(int id, [FromBody]JObject values)
        {
            Venue obj = new Venue()
            {
                Score = values["score"].ToString(),
                VenueAddress = values["venueAddress"].ToString(),
                VenueImg = values["venueImg"].ToString(),
                VenueName = values["venueName"].ToString(),
                AvePrice = Convert.ToDecimal(values["avePrice"]),
                Status = Convert.ToInt32(values["status"])
            };
            bool result = false;
            if (id != 0)
            {
                obj.Id = id;
                result = bll.Update(obj);
            }
            else
            {
                result = bll.Insert(obj);
            }
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]JObject values)
        {
            ApiResult res = new ApiResult
            {
                Status = 200,
                Error = "success",
                Obj = bll.Update(new Venue
                {
                    Score = values["score"].ToString(),
                    VenueAddress = values["venueAddress"].ToString(),
                    VenueImg = values["venueImg"].ToString(),
                    VenueName = values["venueName"].ToString(),
                    AvePrice = Convert.ToDecimal(values["avePrice"]),
                    Status = Convert.ToInt32(values["status"])
                })
            };
            return Json(res);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
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
