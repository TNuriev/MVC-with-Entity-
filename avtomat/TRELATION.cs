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
    [Table("TRELATION")]
    public class TRELATION
    {
        [Key, Column(Order=0)]
        public long id_parent { get; set; }
        [Key, Column(Order=1)]
        public long id_child { get; set; }
        //public TGROUP Parent { get; set; }
        //public TGROUP Child { get; set; }
    }


}
