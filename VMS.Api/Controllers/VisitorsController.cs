using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VMS.Api.Models;
using VMS.EF;
using VMS.EF.Entitities;

namespace VMS.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VisitorsController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(VisitorModel entity)
        {
            if (ModelState.IsValid)
            {
                using(var db = new vmsDBContext())
                {
                    Visitors vstr = new Visitors();
                    vstr.Name = entity.Name;
                    vstr.Email = entity.Email;
                    vstr.Phone = entity.Phone;
                    vstr.IdCard = entity.IdCard;
                    vstr.Vehicle = entity.Vehicle;
                    vstr.VehicleNu = entity.VehicleNu;
                    vstr.Color = entity.Color;
                    vstr.ParkineZone = entity.ParkineZone;
                    vstr.Building = entity.Building;
                    vstr.MeeTTo = entity.MeeTTo;
                    vstr.TokenNo = entity.TokenNo;
                    vstr.EntryDate = DateTime.Now;
                    db.Visitors.Add(vstr);
                    db.SaveChanges();
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new { entity });
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [HttpGet]
        public IHttpActionResult Get()
        {

            return Ok();
               
        }
    }
}
