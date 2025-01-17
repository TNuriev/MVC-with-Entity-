using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace avtomat
{
    [Table("TGROUP")]
    public class TGROUP
    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Указывает, что ID будет автоинкрементироваться
        [Column("Id", TypeName = "bigint")]
        public long Id { get; set; }

        [Required] // Указывает, что поле не может быть null
        [Column("Name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        
    }
   
}
