using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace avtomat
{
    public partial class Form1 : Form
    {
        public Context _context;
        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //Получаемраскрываемыйузел
            var expandedNode = e.Node;
            if (expandedNode != null)
            {
                if (expandedNode.Name == "TechnicalGroup")
                {
                    e.Cancel = true;
                    return;
                }
                expandedNode.Nodes.Clear();
                int index = expandedNode.Name.IndexOf('|');
                string id = expandedNode.Name.Substring(0, index);
                string name = expandedNode.Name.Substring(index + 1);
                if (name == "Group")
                {
                    var groupId = int.Parse(id);

                    // Загрузка дочерних групп и свойств из базы данных
                    var childGroups = _context.TGroup.Where(g => g.Id == groupId).ToList();
                    var properties = _context.TPROPERTY.Where(p => p.group_id == groupId).ToList();

                    // Добавляем дочерние группы
                    foreach (var group in childGroups)
                    {
                        var groupNode = new TreeNode()
                        {
                            Text = group.Name,
                            Name = group.Id + "|Group"
                        };

                        

                        
                        var techNode = new TreeNode()
                        {
                            Text = "TechnicalGroup",
                            Name = "TechnicalGroup"
                        };

                        groupNode.Nodes.Add(techNode);
                        expandedNode.Nodes.Add(groupNode);
                    }

                    // Добавляем свойства
                    foreach (var property in properties)
                    {
                        var propertyNode = new TreeNode()
                        {
                            Text = property.prop_name,
                            Name = property.id_prop + "|Property"
                        };

                        expandedNode.Nodes.Add(propertyNode);
                    }
                }
                if (name == "Property") { return; }
            }
            if (expandedNode == null || expandedNode.Nodes.Count == 0)
            {
                MessageBox.Show(@"Ошибка: узел пустой!");
                e.Cancel = true; // Отменяем раскрытие
                return;
            }

        }


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
            //Подписка на событие FormClosing, написать делегат
            
            treeView1.BeforeExpand += TreeView1_BeforeExpand;
            // Создается экземпляр _context класса TestContext и автоматически
            // устанавливается связь с базой данных MS SQL Server согласно тем настройкам,
            // указанным в файле App.config.
            // В конструктор класса TestContext передается наименование подключения, 
            // прописанногов файле App.config.
            // А именно, название подключения - TestConnection.
            _context = new Context("TestConnection");// хз на что ругается
            FormClosing += Form1_FormClosing;
            //var child1 = new TreeNode()
            //{
            //    Text = "Группа 1",
            //    Name = "46 | Group"
            //};
            //var root = new TreeNode()
            //{
            //    Text = "Группа 1",
            //    Name = "1 | Group"
            //};
            //var property1 = new TreeNode()
            //{
            //    Text = "Свойство 1",
            //    Name = "1|Property"
            //};

            //child1.Nodes.Add(property1);
            //root.Nodes.Add(child1);
            //treeView4.Nodes.Add(root);
            InitRootGroup();
            // 1. Создание новой сущности с названием "Моя первая сущность".
            // Отметим, что id в данном случае можно не задавать, он найдется автоматически.
            //CreateNewTGROUP("Моя первая сущность");
            //CreateNewTPROPERTY("art", "000", 1);
            //CreateNewTRELATION(3, 4);
            //DeleteTgroup(4);
            //UpdateTRELATION(3, 4, 6, 6); нельзя менять, это составной первичный ключ долбаеб
            var res = _context.SaveChanges();
            
            //if (res < 0)
            //    MessageBox.Show(@"Возникли ошибки при создании объекта с названием 'Моя первая сущность'");

            //// 2. Задаем параметр idUpdate = 1.
            //// И поменяем у найденной сущности параметр TestName на значение "Измененноe наименование".
            //var idUpdate = 1;//При повторном запуске программы можно будет поменять на другой сущестующий id.
            //UpdateName(idUpdate, "Измененноe наименование");
            //res = _context.SaveChanges();
            //if (res < 0)
            //    MessageBox.Show(@"Возникли ошибки при обновлении объекта с id = " + idUpdate);

            // 3. Задаем параметр idDel=1. Тогда произойдет 
            // удаление сущности из таблицы "TestTable", у которого idDel=1.
            //int idDel1 = 1;
            //DeleteTPROPERTY(idDel1);
            //int idDel = 20;//При повтором запуске можно будет значение переменной idDel поменять на другое. Например, idDel=4.
            //DeleteTgroup(idDel);
            //res = _context.SaveChanges();
            //if (res < 0)
            //    MessageBox.Show(@"Возникли ошибки при удалении объекта, у которго id = " + idDel);
        }

        private void CreateNewTGROUP(string name)
        {
            if (_context == null) return;
            var Tgr = _context.TGroup.FirstOrDefault();
            if (Tgr == null)
            {
                var newEntity = new TGROUP()
                {
                    Id = 1,
                    Name = name
                };
                _context.TGroup.Add(newEntity);
            }
            else {
                var maxId = _context.TGroup.Max(x => x.Id) + 1;
                var newEntity = new TGROUP()
                {
                    Id = maxId,
                    Name = name
                };
                _context.TGroup.Add(newEntity);
            }
            //+
        }
        
        private void UpdateTGROUP(int id, string name)
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

            var tp = _context.TPROPERTY
                .Where(x => x.group_id == id)
                .ToList();
            _context.TPROPERTY.RemoveRange(tp);
            _context.SaveChanges();
            _context.TGroup.Remove(test);
            //+
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //private void DeletetTrelation(int id)
        //{
        //    var test = _context.TRelation.FirstOrDefault();
        //    if (test == null)
        //    {
        //        MessageBox.Show(@"лошары");
        //        return;
        //    }
            
        //    MessageBox.Show($"{test.id_child} + {test.id_parent}");
        //}
        private void CreateNewTPROPERTY(string name, string value, long group_id)
        {
            if (_context == null) return;
            var Tgr = _context.TPROPERTY.FirstOrDefault();
            if (Tgr == null)
            {
                TGROUP test = _context.TGroup.Find(group_id);
                if (test != null)
                {
                    var newTPROPERTY = new TPROPERTY()
                    {
                        id_prop = 1,
                        prop_name = name,
                        value = value,
                        group_id = group_id // прописать искл для наличия в таблице TGROUP
                    };
                    _context.TPROPERTY.Add(newTPROPERTY);
                }
                else
                {
                    MessageBox.Show(@"Возникли ошибки при создании элемента Tproperty ");
                    return ;
                }
            }
            else 
            {
                TGROUP test = _context.TGroup.Find(group_id);
                if (test != null) {
                    var maxId = _context.TPROPERTY.Max(x => x.id_prop) + 1;
                    var newTPROPERTY = new TPROPERTY()
                    {
                        id_prop = maxId,
                        prop_name = name,
                        value = value,
                        group_id = group_id // прописать искл для наличия в таблице TGROUP
                    };
                    _context.TPROPERTY.Add(newTPROPERTY);
                }
                else 
                { 
                    MessageBox.Show(@"Возникли ошибки при создании элемента Tproperty ");
                    return;
                }
            }
            //+
        }
        private void DeleteTProperty(int id)
        {
            if (_context == null) return;
            // Из базы данных находится объект с заданным параметров id
            var test = _context.TPROPERTY.SingleOrDefault(x => x.id_prop == id);
            if (test == null)
            {
                MessageBox.Show($@"Объект с id = {id} не найден!");
                return;
            }
            // Происходит удаление объекта testEntityForDelete из базы данных
            _context.TPROPERTY.Remove(test);
            //+
        }
        private void UpdateNameTPROPERTY(int id, string name, string value, long group_id)
        {
            if (_context == null) return;

            var updateTPROPERTY = _context.TPROPERTY.FirstOrDefault(x => x.id_prop == id);
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
            }
            else
            {
                MessageBox.Show(@"Объект невозвожен к обновлению, ошибка в соответствии с полем group_id");
                return ;
            }
            //+
        }
        private void ReadTPROPERTY(long id)
        {
            if ( _context == null) return;
        }
        private void CreateNewTRELATION(long id_parent, long id_child)
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
            }
            else
            {
                MessageBox.Show(@"Объект невозвожен к созданию, ошибка в наличии входящих данных в таблице TGROUP");
                return;

            }
            //+
        }
        //нельзя менять составной первичный ключ 
        //private void UpdateTRELATION(long id_parent, long id_child, long new_id_parent, long new_id_child)
        //{
        //    if (_context == null) return;
        //    var Tgr = _context.TRelation.FirstOrDefault();
        //    var test = _context.TRelation.FirstOrDefault(x => x.id_parent == new_id_parent && x.id_child == new_id_child);
        //    var test3 = _context.TRelation.FirstOrDefault(x => x.id_parent == id_parent && x.id_child == id_child);
        //    if (test != null)
        //    {
        //        MessageBox.Show(@"Объект невозвожен к обновлению, в таблице уже есть объект с такими параметрами");
        //        return;
        //    }
        //    TGROUP test1 = _context.TGroup.Find(id_parent);
        //    TGROUP test2 = _context.TGroup.Find(id_child);
        //    if (test1 != null && test2 != null)
        //    {
        //        test3.id_parent = new_id_parent;
        //        test3.id_child = new_id_child;
        //        return;
        //    }
        //    MessageBox.Show(@"Объект невозвожен к обновлению, ошибка в наличии входящих данных в таблице TGROUP");
        //    //+
        //}
        private void DeletetTrelation(int idparent, int idchild)
        {
            var test = _context.TRelation.FirstOrDefault(x => x.id_parent == idparent && x.id_child == idchild);

            if (test == null)
            {
                MessageBox.Show($@"Объект с id_parent = {idparent} и с id_child = {idchild} не найден!");
                return;
            }
            _context.TRelation.Remove(test);
            //+
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
        private void InitRootGroup()
        {
            var test = _context.TGroup.Find(1);
            if (test == null) 
            {
                MessageBox.Show($@"Отсутствие коревой группы в базе данных!");
                return;
            }
            
            
            TreeNode rootNode = new TreeNode()
            {
                Text = test.Name,

                Name = test.Id + "|" + "Group"//
            };
            TreeNode techNode = new TreeNode()
            {
                Text = "TechnicalGroup",
                Name = "TechnicalGroup"
            };
            rootNode.Nodes.Add(techNode);
            treeView1.Nodes.Add(rootNode);
        }
    }
}