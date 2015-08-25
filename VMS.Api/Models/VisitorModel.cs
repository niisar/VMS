using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Api.Models
{
    public class VisitorModel
    {
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public string Guests { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdCard { get; set; }
        public string Vehicle { get; set; }
        public string VehicleNu { get; set; }
        public string Color { get; set; }
        public string ParkineZone { get; set; }
        public string Building { get; set; }
        public string MeeTTo { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string TokenNo { get; set; }
        //public string Status { get; set; }
        public DateTime EntryDate { get; set; }
    }
}