using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avtomat
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            using (Context DB = new Context("TestConnection"))
            {

                //TGROUP test = new TGROUP { Id = 15, Name = "NNN" };
                //test.Id = 16;
                //test.Name = "Cola";
                //DB.TGroup.Add(test);
                //var test = DB.TGroup.ToList();
                //test[0].Name = "x1";

                // Сохраняем изменения в базе данных
                //TPROPERTY test = new TPROPERTY
                //{
                //    id_prop = 1,
                //    prop_name = "Alex",
                //    value = "art",
                //    group_id = 1
                //};
                //DB.TProperty.Add(test);
                //DB.SaveChanges();
            }


        }


    }
    
}
