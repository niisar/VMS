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
    public class SecurityCheckinController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SecurityAllVisitor()
        {
            using (var db = new vmsDBContext())
            {
                var task = from inout in db.InOuts
                           where inout.Status == "Security Checkout"
                           join vst in db.Visitors on inout.VisitorID equals vst.VisitorID
                               into t
                           from rt in t.DefaultIfEmpty()
                           orderby inout.EntryDate
                           select new
                           {
                               rt.Name,
                               Vehicle = rt.Vehicle,
                               rt.Building,
                               rt.MeeTTo,
                               inout.InTime,
                               inout.OutTime,
                               inout.ID
                           };
                return Ok(task.ToList());
            }
        }

        [HttpPost]
        public IHttpActionResult CheckOut(int id)
        {
            using (var db = new vmsDBContext())
            {
                var task = (from inout in db.InOuts
                           where inout.ID == id
                           select inout).SingleOrDefault();
                task.Status = "Security Checkout";
                db.SaveChanges();
                return Ok("OK");
            }
        }


        [HttpGet]
        public IHttpActionResult SecurityChekedInVisitor()
        {
            using (var db = new vmsDBContext())
            {
                var task = from inout in db.InOuts
                           where inout.Status == "Security Checkin" && inout.Status != "Security Checkout"
                           join vst in db.Visitors on inout.VisitorID equals vst.VisitorID
                               into t
                           from rt in t.DefaultIfEmpty()
                           orderby inout.EntryDate
                           select new
                           {
                               rt.Name,
                               Vehicle = rt.Vehicle,
                               rt.Building,
                               rt.MeeTTo,
                               inout.InTime,
                               inout.OutTime,
                               rt.TokenNo,
                               inout.ID
                           };
                return Ok(task.ToList());
            }
        }
    }
}
