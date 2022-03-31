using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DZ5
{
    public partial class Form2 : Form
    {
        Products prod;
        List<Products> ProductList;
        bool AddEditCheck;
        public Form2(Products prod, List<Products> ProductList, bool AddEditCheck)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;    // Старт формы по центру экрана  
            this.prod = prod;                                       // Ссылка на продукт
            this.ProductList = ProductList;                         // Ссылка на список продуктов
            this.AddEditCheck = AddEditCheck;                       // Ссылка проверки функции Добавление\Редактироване
            comboBox1.DataSource = ProductList;                     // Использование списка товаров как ресурса для всплыващего меню
            if (AddEditCheck == true)                               // Блокировка кнопок Добавить\Редакировать
            {
                button_add.Enabled = true;
                button_Edit.Enabled = false;
            }
            else
            {
                button_add.Enabled = false;
                button_Edit.Enabled = true;
            }
        }

        // Ивент обработки кнопки добавить
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на пустую строку
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Заполните все поля"); return;
            }
            // Проверка на пустой товар
            if (prod == null)
            {
                prod = new Products();
            }
            prod.Name = textBox1.Text;                              // Запись названия товара
            prod.Description = textBox2.Text;                       // Запись описания товара
            try
            {
                prod.Price = Convert.ToDouble(textBox3.Text);       // Запись цены товара
            }
            catch
            {
                MessageBox.Show("Цена указана неверно");            // Проверка на корректность цены
                return;
            }
            this.DialogResult = DialogResult.OK;                    // Закрытие модально окна
        }

        // Ивент обработки кнопки Редактировине
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (ProductList == null)                                // Проверка на пустой список
                MessageBox.Show("Список Пуст");
            Products p = ProductList[comboBox1.SelectedIndex];      // Запись данных колекции в переменную
                                                                    // Проверка на пустые строки
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            { 
                MessageBox.Show("Заполните все поля"); 
                return;
            }
            p.Name = textBox1.Text;                                 // Запись нового имени
            p.Description = textBox2.Text;                          // Запись нового описания
            p.Price = Convert.ToDouble(textBox3.Text);              // Запись новой цены
            ProductList[comboBox1.SelectedIndex] = p;               // Запись новых данных обрато в колекцию
            this.DialogResult = DialogResult.OK;                    // Закрытие модальной формы
        }
    }
}
