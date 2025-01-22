using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avtomat
{
    public class TRELATION
    {
        public long IdParent { get; set; }
        public long IdChild { get; set; }
        public TGROUP Parent { get; set; }
        public TGROUP Child { get; set; }
    }


}
