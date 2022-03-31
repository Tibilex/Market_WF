using System;

namespace DZ5
{
    public class Products
    {
        string name;            // Поле названия товара
        string description;     // Поле Характеристик и описания товара
        double price;           // Поле Цены товара

        // Аксессор поля name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Аксессор поля description
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Аксессор поля price
        public double Price
        {
            get { return price; }
            set 
            {
                if (price < 0) throw new Exception("Цена не может быть меньше нуля");
                price = value;
            }
        }

        //
        public Products()
        {
            Name = "";
            Description = "";
            Price = 0;
        }

        // Конструктор с параметрами
        public Products(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        // Переопределение метода ToString()
        public override string ToString()
        {
            return $"{Name }Описание:{ Description}";
        }
    }
}
