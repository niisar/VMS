using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.EF.Entitities
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }
        public int Name { get; set; }
        public int Email { get; set; }
        public int SMS { get; set; }
        public int Designation { get; set; }
    }
}
