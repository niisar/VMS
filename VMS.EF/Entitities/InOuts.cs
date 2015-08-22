using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.EF.Entitities
{
    public class InOuts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int VisitorID { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Status { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
