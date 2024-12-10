using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfAppCodeFirst
{
    public class CustumerContext : DbContext
    {
        public CustumerContext() : base("CodeFirst") { }

        public DbSet<Custumer> Custumers { get; set; }
    }
}
