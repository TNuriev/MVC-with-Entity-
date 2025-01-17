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
        public Form1()
        {
            InitializeComponent();
        }

    }

    public partial class TestContext : DbContext
    {
        public TestContext(string connectionName) : base(connectionName)
        {
        }
        public DbSet<TGROUP> TGROUPs => Set<TGROUP>();
        public DbSet<TRELATION> TRELATIONs => Set<TRELATION>();
        //public DbSet<TGROUP> TestConnection { get; set; }
        //public DbSet<TRELATION> RelationEntities { get; set; }
    }
}

