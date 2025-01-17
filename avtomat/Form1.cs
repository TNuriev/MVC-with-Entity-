using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace avtomat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    [Table("TGROUP")]
    public class TestEntityClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
    public partial class Context : DbContext
    {
        public Context(string conneсtionName) : base(conneсtionName)
        {
        }
        public virtual DbSet<TestEntityClass> TestEntityProperty { get; set; }
    }

    [Table("TRELATION")]
    public class TestEntityClass2
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_parent")]
        public int Id_parent { get; set; }
        [Column("id_child")]
        public string Id_child { get; set; }
    }
    public partial class Context2 : DbContext
    {
        public Context2(string conneсtionName) : base(conneсtionName)
        {
        }
        public virtual DbSet<TestEntityClass> TestEntityProperty { get; set; }
    }

}
