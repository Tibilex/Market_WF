using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DZ5
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;    // Старт формы по центру экрана   
        }

        // Колекция обьектов класса товар
        public List<Products> ProductList = new List<Products>();

        // Ивент обработк ивыпадающего меню
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Products p = ProductList[comboBox1.SelectedIndex];      // Данные продукта записавются в переменую в зависимости от выбора
            textBox1.Text = p.Price.ToString();                     // Показ цены товара в поле TextBox
        }

        // Ивент кнопки добавления товара в список
        double sum;                                                 // Переменная подсчета суммы стоимости
        void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)                      // Проверка на пустой список товаров
                MessageBox.Show("Список пуст");
            else
            {
                listBox1.Items.Add(comboBox1.SelectedItem);         // Добавление в список товара из выпадающего списка
                Products p = ProductList[comboBox1.SelectedIndex];  // Данные продукта записавются в переменую в зависимости от выбора
                sum += p.Price;                                     // Суммирование цены
                label_totalSum.Text = sum.ToString();               // Вывод в программу
            }
        }

        // Ивент кнопки выхода из программы
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Ивент кнопки добавления товара в базу магазина
        Products prod;                                              // Переменная класса продукт
        Form2 form2;                                                // Переменная класса второй формы
        private void button3_Click(object sender, EventArgs e)
        {
            prod = new Products();
            form2 = new Form2(prod, this.ProductList, true);
            form2.ShowDialog();                                     // Вызов второй формы
            comboBox1.Items.Add(prod);                              // Запись данных в выпадающее меню
            ProductList.Add(prod);                                  // Запись данных в колекцию продуктов
        }

        // Ивент кнопки редактирования товара
        private void button4_Click(object sender, EventArgs e)
        {
            form2 = new Form2(prod, this.ProductList, false);
            form2.ShowDialog();
            comboBox1.DataSource = ProductList;
        }
    }
}