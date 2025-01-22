using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avtomat
{
    public partial class Context : DbContext
    {
        public DbSet<TGROUP> TGroup { get; set; }
        public DbSet<TRELATION> TRelation { get; set; }

        public Context(string conneсtionName) : base(conneсtionName)
        {
        }
    }
}
