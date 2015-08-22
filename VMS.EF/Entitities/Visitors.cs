using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.EF.Entitities
{
    public class Visitors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdCard { get; set; }
        public string Vehicle { get; set; }
        public string VehicleNu { get; set; }
        public string Color { get; set; }
        public string ParkineZone { get; set; }
        public string Building { get; set; }
        public string MeeTTo { get; set; }
        public string TokenNo { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
