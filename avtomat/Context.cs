using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace avtomat
{
    public class Context : DbContext
    {
        public DbSet<TGROUP> TGroup { get; set; }
        public DbSet<TRELATION> TRelation { get; set; }

        public DbSet<TPROPERTY> TProperty { get; set; }
        public Context(string name) : base(name)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Указываем правильные имена таблиц для TGROUP и TRELATION
        //    modelBuilder.Entity<TGROUP>().ToTable("TGROUP");
        //    modelBuilder.Entity<TRELATION>().ToTable("TRELATION");

        //    // Устанавливаем явное соответствие столбцов
        //    modelBuilder.Entity<TGROUP>()
        //        .Property(t => t.Id)
        //        .HasColumnName("id");  // Именуем столбец в базе как "id" вместо "Id"

        //    modelBuilder.Entity<TRELATION>()
        //        .Property(tr => tr.IdParent)
        //        .HasColumnName("id_parent");  // Именуем столбец в базе как "id_parent"

        //    modelBuilder.Entity<TRELATION>()
        //        .Property(tr => tr.IdChild)
        //        .HasColumnName("id_child");  // Именуем столбец в базе как "id_child"

        //    // Устанавливаем внешний ключ и составной ключ для TRELATION
        //    modelBuilder.Entity<TRELATION>()
        //        .HasRequired(tr => tr.Parent)  // Связь с родительской группой
        //        .WithMany()                   // Родитель может иметь много дочерних
        //        .HasForeignKey(tr => tr.IdParent)  // Указываем внешний ключ
        //        .WillCascadeOnDelete(false);        // Отключаем каскадное удаление

        //    modelBuilder.Entity<TRELATION>()
        //        .HasRequired(tr => tr.Child)  // Связь с дочерней группой
        //        .WithMany()                   // Дочерняя группа может быть привязана только к одному родителю
        //        .HasForeignKey(tr => tr.IdChild)  // Указываем внешний ключ
        //        .WillCascadeOnDelete(false);        // Отключаем каскадное удаление

        //    // Устанавливаем составной ключ для TRELATION
        //    modelBuilder.Entity<TRELATION>()
        //        .HasKey(tr => new { tr.IdParent, tr.IdChild });
        //}
    }
}
