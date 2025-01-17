using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avtomat
{
    [Table("TRELATION")]
    public class TRELATION
    {
        [Key] // Первый столбец составного ключа
        [ForeignKey("ParentGroup")] // Указывает связь с таблицей TGROUP
        [Column("id_parent", TypeName = "bigint")]
        public long IdParent { get; set; }

        [Key] // Второй столбец составного ключа
        [ForeignKey("ChildGroup")] // Указывает связь с таблицей TGROUP
        [Column("id_child", TypeName = "bigint")]
        public long IdChild { get; set; }

        // Навигационные свойства
        public TGROUP ParentGroup { get; set; }
        public TGROUP ChildGroup { get; set; }
    }
}
