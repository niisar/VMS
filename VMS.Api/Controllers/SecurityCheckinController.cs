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
                               inout.ID,
                               inout.Status
                           };
                return Ok(task.ToList());
            }
        }

        [HttpPost]
        public IHttpActionResult CheckOut(int id)
        {
            using (var db = new vmsDBContext())
            {
                InOuts inout = new InOuts();
                inout.VisitorID = id;
                inout.InTime = GetCheckInTime(id);
                inout.OutTime = string.Format("{0:HH:mm tt}", DateTime.Now);
                inout.Status = "Security Checkout";
                inout.EntryDate = DateTime.Now;
                
                db.InOuts.Add(inout);
                db.SaveChanges();
               
            }
            using (var db = new vmsDBContext())
            {
                var inouts = (from inout in db.InOuts
                             where inout.VisitorID.Equals(id)
                             && inout.Status.Equals("Security Checkin")
                             select inout).SingleOrDefault();
                inouts.OutTime = string.Format("{0:HH:mm tt}", DateTime.Now);
                db.SaveChanges();
            }
            return Ok("OK");
        }

        protected string GetCheckInTime(int id)
        {
            string strCheckInTime ="";
            using(var db = new vmsDBContext())
            {
                var CheckInTime = (from inout in db.InOuts
                                   where inout.VisitorID.Equals(id)
                                   && inout.Status.Equals("Security Checkin")
                                   select inout).SingleOrDefault();
                strCheckInTime = CheckInTime.InTime;
            }
            return strCheckInTime;
        }


        [HttpGet]
        public IHttpActionResult SecurityChekedInVisitor()
        {
            using (var db = new vmsDBContext())
            {
                var task = from inout in db.InOuts
                           where inout.Status == "Security Checkin" 
                           && (inout.OutTime.Equals(null) || inout.OutTime.Equals(string.Empty))
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
                               inout.Status,
                               rt.TokenNo,
                               rt.VisitorID
                           };
                return Ok(task.ToList());
            }
        }
    }
}
