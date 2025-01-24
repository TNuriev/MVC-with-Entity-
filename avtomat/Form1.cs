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
using System.IO;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;


namespace avtomat
{
    public partial class Form1 : Form
    {
        private Context _context;
        public Form1()
        {

            InitializeComponent();
            //Подписка на событие FormClosing, написать делегат
            FormClosing += Form1_FormClosing;
            // Создается экземпляр _context класса TestContext и автоматически
            // устанавливается связь с базой данных MS SQL Server согласно тем настройкам,
            // указанным в файле App.config.
            // В конструктор класса TestContext передается наименование подключения, 
            // прописанногов файле App.config.
            // А именно, название подключения - TestConnection.
            _context = new Context("TestConnection");// хз на что ругается

            //// 1. Создание новой сущности с названием "Моя первая сущность".
            //// Отметим, что id в данном случае можно не задавать, он найдется автоматически.
            //CreateNewTestEntity("Моя первая сущность");
            //var res = _context.SaveChanges();
            //if (res < 0)
            //    MessageBox.Show(@"Возникли ошибки при создании объекта с названием 'Моя первая сущность'");

            //// 2. Задаем параметр idUpdate = 1.
            //// И поменяем у найденной сущности параметр TestName на значение "Измененноe наименование".
            //var idUpdate = 1;//При повторном запуске программы можно будет поменять на другой сущестующий id.
            //UpdateName(idUpdate, "Измененноe наименование");
            //res = _context.SaveChanges();
            //if (res < 0)
            //    MessageBox.Show(@"Возникли ошибки при обновлении объекта с id = " + idUpdate);

            //// 3. Задаем параметр idDel=1. Тогда произойдет 
            //// удаление сущности из таблицы "TestTable", у которого idDel=1.
            //int idDel = 1;//При повтором запуске можно будет значение переменной idDel поменять на другое. Например, idDel=4.
            //DeleteTestEntity(idDel);
            //res = _context.SaveChanges();
            //if (res < 0)
            //    MessageBox.Show(@"Возникли ошибки при удалении объекта, у которго id = " + idDel);
            //DeletetTrelation(1, 2);
            //DeletetProperty(1);
            DeleteTgroup(1);
            _context.SaveChanges();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Database.Connection.Close();
        }
      
        private void DeleteTgroup(int id)
        {
            
            if (_context == null) return;
            
            var test = _context.TGroup.SingleOrDefault(x => x.Id == id);
            if (test == null)
            {
                MessageBox.Show($@"Объект с id = {id} не найден!");
                return;
            }
            var tr = _context.TRelation
                    .Where(x => x.id_parent == id || x.id_child == id)  
                    .ToList();
            _context.TRelation.RemoveRange(tr);
            
            var tp = _context.TProperty
                .Where(x => x.group_id == id)
                .ToList();
            _context.TProperty .RemoveRange(tp);

            _context.SaveChanges();

            _context.TGroup.Remove(test);
            
        }
        private void DeletetTrelation(int idparent, int idchild)
        {
            var test = _context.TRelation.FirstOrDefault(x => x.id_parent == idparent && x.id_child == idchild);

            if (test == null)
            {
                MessageBox.Show($@"Объект с id_parent = {idparent} и с id_child = {idchild} не найде!");
                return;
            }
            _context.TRelation.Remove(test);
        }
        private void DeletetProperty(int id)
        {
            if (_context == null) return;
            // Из базы данных находится объект с заданным параметров id
            var test = _context.TProperty.SingleOrDefault(x => x.id_prop == id);
            if (test == null)
            {
                MessageBox.Show($@"Объект с id = {id} не найден!");
                return;
            }
            // Происходит удаление объекта testEntityForDelete из базы данных
            _context.TProperty.Remove(test);
        }
        private void CreateNewTgroup(string name)
        {
            if (_context == null) return;
            var Tgr = _context.TGroup.FirstOrDefault();
            if (Tgr == null)
            {
                var newy = new TGROUP()
                {
                    Id = 1,
                    Name = name
                };
                _context.TGroup.Add(newy);
                return;
            }  
            var maxId = _context.TGroup.Max(x => x.Id) + 1;
            var newEntity = new TGROUP()
            {
                Id = maxId,
                Name = name
            };
            _context.TGroup.Add(newEntity);
            
            //+
        }
        private void UpdateTgroup(int id, string name)
        {
            if (_context == null) return;

            var testEntityForUpdate = _context.TGroup.FirstOrDefault(x => x.Id == id);
            if (testEntityForUpdate == null)
            {
                MessageBox.Show(@"Объект, предназначенный для обновления, ненайден");
                return;
            }
            testEntityForUpdate.Name = name;
            //+
        }
        private void CreateNewTproperty(string name, string value, long group_id)
        {
            if (_context == null) return;
            var Tgr = _context.TProperty.FirstOrDefault();
            if (Tgr == null)
            {
                TGROUP test1 = _context.TGroup.Find(group_id);
                if (test1 != null)
                {
                    var newTPR = new TPROPERTY()
                    {
                        id_prop = 1,
                        prop_name = name,
                        value = value,
                        group_id = group_id // прописать искл для наличия в таблице TGROUP
                    };
                    _context.TProperty.Add(newTPR);
                    return;
                }               
                MessageBox.Show(@"Возникли ошибки при создании элемента Tproperty ");
                return;   
            }                        
            TGROUP test = _context.TGroup.Find(group_id);
            if (test != null)
            {
                var maxId = _context.TProperty.Max(x => x.id_prop) + 1;
                var newTPROPERTY = new TPROPERTY()
                {
                    id_prop = maxId,
                    prop_name = name,
                    value = value,
                    group_id = group_id // прописать искл для наличия в таблице TGROUP
                };
                _context.TProperty.Add(newTPROPERTY);
                return;
            }                               
            MessageBox.Show(@"Возникли ошибки при создании элемента Tproperty ");
            return;
                
            //+
        }
        private void UpdateNameTProperty(int id, string name, string value, long group_id)
        {
            if (_context == null) return;

            var updateTPROPERTY = _context.TProperty.FirstOrDefault(x => x.id_prop == id);
            if (updateTPROPERTY == null)
            {
                MessageBox.Show(@"Объект, предназначенный для обновления, ненайден");
                return;
            }
            TGROUP test = _context.TGroup.Find(group_id);
            if (test != null)
            {
                updateTPROPERTY.prop_name = name;
                updateTPROPERTY.value = value;
                updateTPROPERTY.group_id = group_id;
                return;
            }            
            MessageBox.Show(@"Объект невозвожен к обновлению, ошибка в соответствии с полем group_id");
            return;
            
            //+
        }
        private void CreateNewTrelation(long id_parent, long id_child)
        {
            if (_context == null) return;
            var Tgr = _context.TRelation.FirstOrDefault();
            var test = _context.TRelation.FirstOrDefault(x => x.id_parent == id_parent && x.id_child == id_child);
            if (test != null)
            {
                MessageBox.Show(@"Объект невозвожен к созданию, в таблице уже есть объект с такими параметрами");
                return;
            }
            TGROUP test1 = _context.TGroup.Find(id_parent);
            TGROUP test2 = _context.TGroup.Find(id_child);
            if (test1 != null && test2 != null)
            {
                var newEntity = new TRELATION()
                {
                    id_parent = id_parent,
                    id_child = id_child
                };
                _context.TRelation.Add(newEntity);
                return;
            }                     
            MessageBox.Show(@"Объект невозвожен к созданию, ошибка в наличии входящих данных в таблице TGROUP");
            return;            
            //+
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        

    }
}