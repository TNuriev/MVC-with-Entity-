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
        [ForeignKey("ParentGroup")] // Указывает связь с таблицей TGROUP
        public long IdParent { get; set; }

        [ForeignKey("ChildGroup")] // Указывает связь с таблицей TGROUP
        public long IdChild { get; set; }

        // Навигационные свойства
    }

    
}
