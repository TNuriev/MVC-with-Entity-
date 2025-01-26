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
            
            _context = new Context("TestConnection");
            InitRootGroup();
            treeView2.BeforeExpand += TreeView1_BeforeExpand;
            FormClosing += Form1_FormClosing;
            
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
            _context.TProperty.RemoveRange(tp);

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
        private void UpdateTgroup(long id, string name)
        {
            if (_context == null) return;

            var testEntityForUpdate = _context.TGroup.FirstOrDefault(x => x.Id == id);
            if (testEntityForUpdate == null)
            {
                MessageBox.Show(@"Объект, предназначенный для обновления, ненайден");
                return;
            }
            testEntityForUpdate.Name = name;
            _context.SaveChanges();
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       
        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

            //Получаемраскрываемыйузел
            var expandedNode = e.Node;
            if (expandedNode == null)
            {
                MessageBox.Show(@"Узел пуст!");
                return;
            }
            expandedNode.Nodes.Clear();
            int index = expandedNode.Name.IndexOf('|');
            string id = expandedNode.Name.Substring(0, index);
            string name = expandedNode.Name.Substring(index + 1);
            if (name == "Propety")
            {
                return;
            }
            if (name == "Group")
            {
                var groupId = long.Parse(id);

                // Загрузка дочерних групп и свойств из базы данных
                var childGroups = _context.TRelation.Where(g => g.id_parent == groupId).ToList();
                var properties = _context.TProperty.Where(p => p.group_id == groupId).ToList();

                // Добавляем дочерние группы
                foreach (var group in childGroups)
                {
                    var groupNode = new TreeNode()
                    {
                        Text = _context.TGroup.FirstOrDefault(x => x.Id == group.id_child).Name,
                        Name = group.id_child + "|Group"
                    };

                    // Добавляем технический узел
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
                        Name = property.id_prop + "|Property|" + property.value
                    };

                    expandedNode.Nodes.Add(propertyNode);
                }

            }
           
            }

            //}


            private void InitRootGroup()
        {
            var test = _context.TGroup.Find(1);
            if (test == null)
            {
                MessageBox.Show($@"Отсутствие корневой группы в базе данных");
                return;
            }
            var rootNode = new TreeNode()
            {
                Text = test.Name,
                Name = test.Id + "|Group" 
            };

            var techNode = new TreeNode()
            {
                Text = "TechnicalGroup"
            };

            rootNode.Nodes.Add(techNode);
            treeView2.Nodes.Add(rootNode);
        }

        //Действие команды «Добавить ->Группу»
        private void группуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxRedactionProperty.Visible = false;
            groupBoxRedactionGroup.Visible = true;
            groupBoxRedactionGroup.Enabled = true;
            NameRedactionGroup.Text = string.Empty;
            IdRedactionGroup.Text = _context.TGroup.Max(x => x.Id + 1).ToString();
        }

        //Действие команды «Добавить ->Свойство»
        private void свойствоToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBoxRedactionGroup.Visible = false;
            groupBoxRedactionProperty.Enabled = true;

            var selectedNode = treeView2.SelectedNode;

            
            if (selectedNode == null)
            {
                MessageBox.Show(@"Необходимо выбрать группу в дереве для добавления свойства!");
                return;
            }

            groupBoxRedactionProperty.Visible = true;
            NameRedactionProperty.Text = string.Empty;
            RedactionPropertyValue.Text = string.Empty;

            var nodeNameParts = selectedNode.Name.Split('|');
            if (!long.TryParse(nodeNameParts[0], out var groupId))
            {
                MessageBox.Show(@"Ошибка извлечения ID группы из узла!");
                return;
            }
            IdRedactionProperty.Text = groupId.ToString(); 

        }
        //Действие команды «Редактировать»
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView2.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show(@"Необходимо выбрать группу в дереве для добавления свойства!");
                return;
            }
            var nodeNameParts = selectedNode.Name.Split('|');
            if (nodeNameParts[1] == "Group")
            {
                groupBoxRedactionGroup.Visible = true;
                groupBoxRedactionGroup.Enabled = true;
                groupBoxRedactionProperty.Visible = false;
                NameRedactionGroup.Text = selectedNode.Text;
                IdRedactionGroup.Text = nodeNameParts[0];
            }
            if (nodeNameParts[1] == "Property")
            {
                groupBoxRedactionGroup.Visible = false;
                groupBoxRedactionGroup.Enabled = true;
                groupBoxRedactionProperty.Visible = true;
                groupBoxRedactionProperty.Enabled = true;
                NameRedactionProperty.Text = selectedNode.Text;
                IdRedactionProperty.Text = nodeNameParts[0];
                RedactionPropertyValue.Text = nodeNameParts[2];
            }
            

        }

        //Действие команды «Удалить»
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView2.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show(@"Необходимо выбрать группу в дереве для добавления свойства!");
                return;
            }
            var nodeNameParts = selectedNode.Name.Split('|');
            if (nodeNameParts[1] == "Group")
            {
               
            }
            if (nodeNameParts[1] == "Property")
            {
               
            }
        }
        private void SaveRedactionGroup_Click(object sender, EventArgs e)
        {
            long k;
            if (Int64.TryParse(IdRedactionGroup.Text, out k))
            {
                UpdateTgroup(k, NameRedactionGroup.Text);
                return;
            }
            MessageBox.Show($@"Id = {IdRedactionGroup.Text} не является чилом!");
        }
    }
}