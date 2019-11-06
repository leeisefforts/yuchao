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
        public JsonResult Post([FromBody]JObject values)
        {
            int id = Convert.ToInt32(values["id"]);
            Venue obj = new Venue()
            {
                Score = "",
                VenueAddress = values["venueAddress"].ToString(),
                VenueImg = values["venueImg"].ToString(),
                VenueName = values["venueName"].ToString(),
                AvePrice = Convert.ToDecimal(values["avePrice"]),
                Lng = values["lng"].ToString(),
                Lat = values["lat"].ToString(),
                Status = 1
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


    [Route("api/admin/[controller]")]
    [EnableCors("AllowCors")]
    [Produces("application/json")]
    [ApiController]
    public class SiteApiController : Controller
    {
        private VenueBLL bll = new VenueBLL();

        // GET api/<controller>/5
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
        [HttpGet("{venueId}")]
        public JsonResult GetSite(int venueId)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.GetSiteById(venueId)
            });
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject values)
        {
            int id = Convert.ToInt32(values["id"]);
            Site obj = new Site()
            {
                CreateTime = DateTime.Now,
                VenueId = Convert.ToInt32(values["venueId"]),
                Price = Convert.ToDecimal(values["price"]),
                SiteName = values["siteName"].ToString(),
            };
            bool result = false;
            if (id != 0)
            {
                obj.Id = id;
                result = bll.UpdateSite(obj);
            }
            else
            {
                result = bll.InsertSite(obj);
            }
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });
        }

        [HttpPost("setPrice/{id}")]
        public JsonResult SetPrice(int id, [FromBody]JObject values)
        {
            Venue obj = bll.GetById(id);
            List<Site> list = bll.GetSiteById(id);
            bool result = false;
            if (id != 0)
            {
                obj.MPrice = Convert.ToDecimal(values["mPrice"]);
                obj.NPrice = Convert.ToDecimal(values["nPrice"]);
                obj.APrice = Convert.ToDecimal(values["aPrice"]);

                foreach (var item in list)
                {
                    //if (item.)
                    //{

                    //}
                }
               // result = bll.UpdateSite(obj);
            }
            else
            {
              //  result = bll.InsertSite(obj);
            }
            return Json(new ApiResult()
            {
                Status = 200,
                Error = string.Empty,
                Obj = result
            });
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return Json(new ApiResult
            {
                Status = 200,
                Error = "Success",
                Obj = bll.DeleteSite(id)
            });
        }
    }
}
