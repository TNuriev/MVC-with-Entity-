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
        public Context(string conneсtionName) : base(conneсtionName)
        {
        }
        //public virtual DbSet<TGROUP> Test EntityProperty { get; set; }
    }
}
