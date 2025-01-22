using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace avtomat
{
    public partial class Form1 : Form
    {
        private Context _context;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Закрытие соединения с базой данных
            if (_context != null && _context.Database.Connection.State == System.Data.ConnectionState.Open)
            {
                _context.Database.Connection.Close();
                _context.Dispose(); // Очистка контекста для освобождения ресурсов
            }
        }
        public Form1()
        {

            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }    
        //[Table("TGROUP")]
        //public class TGROUP
        //{
        //    [Key]
        //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Указывает, что ID будет автоинкрементироваться
        //    [Column("Id", TypeName = "bigint")]
        //    public long Id { get; set; }

        //    [Required] // Указывает, что поле не может быть null
        //    [Column("Name", TypeName = "varchar(255)")]
        //    public string Name { get; set; }
        //}

        //public partial class TGROPUP_Context : DbContext
        //{
        //    public TGROPUP_Context(string conneсtionName) : base(conneсtionName)
        //    {
        //    }
        //    public virtual DbSet<TGROUP> TestEntityProperty { get; set; }
        //}

  
        //[Table("TRELATION")]
        //public class TRELATION
        //{
        //    [Key, Column(Order = 0)] // Первый столбец составного ключа
        //    [ForeignKey("ParentGroup")] // Указывает связь с таблицей TGROUP
        //    //[Column("id_parent", TypeName = "bigint")]
        //    public long IdParent { get; set; }

        //    [Key, Column(Order = 1)] // Второй столбец составного ключа
        //    [ForeignKey("ChildGroup")] // Указывает связь с таблицей TGROUP
        //    //[Column("id_child", TypeName = "bigint")]
        //    public long IdChild { get; set; }

        //    // Навигационные свойства
        //    public virtual TGROUP ParentGroup { get; set; }
        //    public virtual TGROUP ChildGroup { get; set; }
        //}

        //public partial class TRELATION_Context : DbContext
        //{
        //    public TRELATION_Context(string conneсtionName) : base(conneсtionName)
        //    {
        //    }
        //    public virtual DbSet<TRELATION> TestEntityProperty { get; set; }
        //}

    }
}

