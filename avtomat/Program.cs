using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //using (Context DB = new Context())
            //{
            //    // Добавляем новые группы в таблицу TGROUP без указания id (он будет сгенерирован автоматически)
            //    //var newGroups = new[]
            //    //{
            //    //    new TGROUP {Id = 7, Name = "x7" },  // id будет сгенерировано автоматически
            //    //    new TGROUP {Id = 8, Name = "x8" },
            //    //    new TGROUP {Id = 9, Name = "x9" }
            //    //};
            //    TGROUP test = new TGROUP
            //    {
            //        Id = 8,
            //        Name = "Alex"
            //    };
            //    DB.TGroup.Add(test);
            //    //DB.TGroup.AddRange(newGroups);

            //    // Добавляем новые отношения в таблицу TRELATION (предполагаем, что IdParent и IdChild существуют)
            //    var newRelations = new[]
            //    {
            //        new TRELATION { IdParent = 1, IdChild = 4 },  // Связи с существующими группами
            //        new TRELATION { IdParent = 1, IdChild = 5 },
            //        new TRELATION { IdParent = 3, IdChild = 8 }
            //    };

            //    DB.TRelation.AddRange(newRelations);

            //    // Сохраняем изменения в базе данных
            //    DB.SaveChanges();
            //}


        }


    }
    
}
