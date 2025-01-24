using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avtomat
{
    [Table("TPROPERTY")]
    public class TPROPERTY
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_prop")]
        public long id_prop { get; set; }
        public string prop_name { get; set; }
        public string value { get; set; }

        [ForeignKey("TGROUP")]
        public long group_id { get; set; }
        public TGROUP TGROUP { get; set; }
    }
}
