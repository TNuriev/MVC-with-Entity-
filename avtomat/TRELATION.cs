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
        [Key, Column(Order = 0)] // Первый столбец составного ключа
        [ForeignKey("ParentGroup")] // Указывает связь с таблицей TGROUP
                                    //[Column("id_parent", TypeName = "bigint")]
        public long IdParent { get; set; }

        [Key, Column(Order = 1)] // Второй столбец составного ключа
        [ForeignKey("ChildGroup")] // Указывает связь с таблицей TGROUP
                                   //[Column("id_child", TypeName = "bigint")]
        public long IdChild { get; set; }

        // Навигационные свойства
        public virtual TGROUP ParentGroup { get; set; }
        public virtual TGROUP ChildGroup { get; set; }
    }

    
}
