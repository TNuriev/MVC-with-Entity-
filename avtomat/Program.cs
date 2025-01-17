using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avtomat
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (TestContext db = new TestContext("TestConnection"))
            {
                TGROUP test = new TGROUP
                {
                    Id = 8,
                    Name = "Alex"
                };
                TRELATION test1 = new TRELATION
                {
                    IdParent = 8,
                    IdChild = 2
                };
                db.TGROUPs.Add(test);
                db.TRELATIONs.Add(test1);
                db.SaveChanges();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
