using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VMS.EF.Entitities;
namespace VMS.EF
{
    public class vmsDBContext :DbContext
    {
        public vmsDBContext()
            : base("conStr1")
        {

        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Visitors> Visitors { get; set; }
        public DbSet<InOuts> InOuts { get; set; }

    }
}
