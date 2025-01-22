using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Data.SqlClient;

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
            //Подписка на событие FormClosing, написать делегат
            FormClosing += Form1_FormClosing;
            // Создается экземпляр _context класса TestContext и автоматически
            // устанавливается связь с базой данных MS SQL Server согласно тем настройкам,
            // указанным в файле App.config.
            // В конструктор класса TestContext передается наименование подключения, 
            // прописанногов файле App.config.
            // А именно, название подключения - TestConnection.
            _context = new Context("TestConnection");// хз на что ругается

            // 1. Создание новой сущности с названием "Моя первая сущность".
            // Отметим, что id в данном случае можно не задавать, он найдется автоматически.
            CreateNewTestEntity("Моя первая сущность");
            var res = _context.SaveChanges();
            if (res < 0)
                MessageBox.Show(@"Возникли ошибки при создании объекта с названием 'Моя первая сущность'");

            // 2. Задаем параметр idUpdate = 1.
            // И поменяем у найденной сущности параметр TestName на значение "Измененноe наименование".
            var idUpdate = 1;//При повторном запуске программы можно будет поменять на другой сущестующий id.
            UpdateName(idUpdate, "Измененноe наименование");
            res = _context.SaveChanges();
            if (res < 0)
                MessageBox.Show(@"Возникли ошибки при обновлении объекта с id = " + idUpdate);

            // 3. Задаем параметр idDel=1. Тогда произойдет 
            // удаление сущности из таблицы "TestTable", у которого idDel=1.
            int idDel = 1;//При повтором запуске можно будет значение переменной idDel поменять на другое. Например, idDel=4.
            DeleteTestEntity(idDel);
            res = _context.SaveChanges();
            if (res < 0)
                MessageBox.Show(@"Возникли ошибки при удалении объекта, у которго id = " + idDel);
        }

        private void CreateNewTestEntity(string name)
        {
            if (_context == null) return;
            var maxId = _context.TGroup.Max(x => x.Id) + 1;
            var newEntity = new TGROUP()
            {
                Id = maxId,
                Name = name
            };
            _context.TGroup.Add(newEntity);

        }
        private void DeleteTestEntity(int id)
        {
            if (_context == null) return;
            // Из базы данных находится объект с заданным параметров id
            var testEntityForDelete = _context.TGroup.SingleOrDefault(x => x.Id == id);
            if (testEntityForDelete == null)
            {
                MessageBox.Show($@"Объект с id = {id} не найден!");
                return;
            }
            // Происходит удаление объекта testEntityForDelete из базы данных
            _context.TGroup.Remove(testEntityForDelete);
        }
        private void UpdateName(int id, string name)
        {
            if (_context == null) return;
            // Находитсяизбазыданныхобъектпопараметруid, укоторогонеобходимоизменитьсвойстваTestName.
            var testEntityForUpdate = _context.TGroup.FirstOrDefault(x => x.Id == id);
            if (testEntityForUpdate == null)
            {
                MessageBox.Show(@"Объект, предназначенныйдляобновления, ненайден");
                return;
            }
            // ПроисходитизменениезначениесвойстваTestNameназначениепеременнойname
            testEntityForUpdate.Name = name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}