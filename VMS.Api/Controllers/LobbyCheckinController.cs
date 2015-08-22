using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VMS.Api.Models;
using VMS.EF;

namespace VMS.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LobbyCheckinController : ApiController
    {
        [HttpGet]
        public IHttpActionResult AllVisitors()
        {
            using (var db = new vmsDBContext())
            {
                var task = from inout in db.InOuts
                           //where inout.Status == "Lobby Checkout"
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
                               EntryDate = (rt.EntryDate).ToString(),
                               inout.Status,
                           };
                return Ok(task.ToList());
            }
        }

        [HttpGet]
        public IHttpActionResult Checkedin(string building)
        {
            using (var db = new vmsDBContext())
            {
                var task = from inout in db.InOuts
                           where inout.Status == "Lobby Checkin" && inout.Status != "Lobby Checkout"
                           join vst in db.Visitors on inout.VisitorID equals vst.VisitorID
                               into t
                           from rt in t.DefaultIfEmpty()
                           where rt.Building == "TCS"
                           orderby inout.EntryDate
                           select new
                           {
                               rt.Name,
                               Vehicle = rt.Vehicle,
                               rt.Building,
                               rt.MeeTTo,
                               inout.InTime,
                               inout.OutTime,
                               rt.TokenNo
                           };
                return Ok(task.ToList());
            }
        }

        [HttpGet]
        public IHttpActionResult MyVisitors(string building)
        {
            using (var db = new vmsDBContext())
            {
                var task = from inout in db.InOuts
                           where inout.Status == "Lobby Checkin" && inout.Status != "Lobby Checkout"
                           join vst in db.Visitors on inout.VisitorID equals vst.VisitorID
                               into t
                           from rt in t.DefaultIfEmpty()
                           where rt.Building == "TCS"
                           orderby inout.EntryDate
                           select new
                           {
                               rt.Name,
                               Vehicle = rt.Vehicle,
                               rt.Building,
                               rt.MeeTTo,
                               inout.InTime,
                               inout.OutTime,
                               rt.TokenNo
                           };
                return Ok(task.ToList());
            }
        }
    }
}
