using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace HW_01_12_2018
{
    class Program
    {

        public class Car
        {
            public string Mark { get; set; }
            public string Model { get; set; }
            public decimal Price { get; set; }
            public string Color { get; set; }

            public Car(string Mark, string Model, string Color, decimal Price)
            {
                this.Mark = Mark;
                this.Model = Model;
                this.Color = Color;
                this.Price = Price;
            }
            public override string ToString()
            {
                return Mark + " " + Model + " " + Color + " " + Price.ToString();
            }
        }
      
        /// <summary>
        /// Функция отображает в консоль все автомобили, цена которых выше decimal-значения
        /// </summary>
        /// <param name="tuple">Tuple(List<Car>, decimal)</param>
        static void zadanie1 (Tuple<List<Car>,decimal> tuple)
        {
            
            int count = 0;
            foreach(Car car in tuple.Item1)
            {
                if (car.Price>tuple.Item2)
                {
                    count++;
                    WriteLine(car);
                }
            }
            if (count == 0) WriteLine("По указанному критерию автомобилей не найдено");
        }

        /// <summary>
        /// Отображает в консоль все автомобили, которые соответствуют заданному цвету
        /// </summary>
        /// <param name="tuple">Tuple(List<Car>, string)</param>
        static void zadanie2(Tuple<List<Car>, string> tuple)
        {
            
            int count = 0;
            foreach(Car car in tuple.Item1)
            {
                if (car.Color == tuple.Item2)
                {
                    ++count;
                    WriteLine(car);
                }
            }
            if (count == 0) WriteLine("Не найдено автомобилей, соответствующих заданному цвету");
        }

        /// <summary>
        /// Отображает в консоль все объекты класса Car, цена которых равна decimal-параметру
        /// и марка которых соответствует string параметру
        /// </summary>
        /// <param name="tuple">Tuple(List<Car>,decimal,string)</param>
        static void zadanie3(Tuple<List<Car>,decimal,string> tuple)
        {
            
            int count = 0;
            foreach(Car car in tuple.Item1)
            {
                if(car.Mark==tuple.Item3 && car.Price==tuple.Item2)
                {
                    WriteLine(car);
                    ++count;
                }
            }
            if (count == 0) WriteLine("По заданному критерию автомобилей не найдено");
        }

        /// <summary>
        /// Подсчет общей стоимости всех объектов класса Car
        /// </summary>
        /// <param name="cars">Tuple(List<Car>)</param>
        /// <returns>decimal</returns>
        static decimal zadanie4(List<Car> cars)
        {
            decimal all_price = 0;
            foreach(Car car in cars)
            {
                all_price += car.Price;
            }
            return all_price;
        }

        /// <summary>
        /// Возвращает количество автомобилей, соответствующих заданному цвету
        /// </summary>
        /// <param name="tuple">Tuple(List<Car>,string)</param>
        /// <returns>int</returns>
        static int zadanie5(Tuple<List<Car>, string> tuple)
        {
            
            int count = 0;            
            count = tuple.Item1.Count(car => car.Color == tuple.Item2);
            return count;
        }

        /// <summary>
        /// В консоль отображается проекция объектов класса Car(Mark, Model),
        /// цена которых ниже decimal-параметра
        /// </summary>
        /// <param name="tuple">Tuple(List<Car>,decimal)</param>
        static void zadanie6(Tuple<List<Car>,decimal> tuple)
        {
            
            var res = tuple.Item1.Where(c => c.Price < tuple.Item2).Select(i => new { Mark = i.Mark, Model = i.Model });
            
            if (res.Count() > 0)
            {
                foreach (var item in res)
                {
                    WriteLine($"Марка: {item.Mark}, Модель: {item.Model}");
                }
            }
            else
            {
                WriteLine("Автомобилей, соответствующих заданному критерию не найдено");
            }
        }

        /// <summary>
        /// Подсчитывает количество объектов класса Car, поле Price которых находится в диапазоне между
        /// первым и вторым decimal-параметрами включительно и поле Color соответствует первому
        /// string-параметру. А также количество объектов класса Car, поле Price которых находится в 
        /// диапазоне между первым и вторым decimal-параметрами включительно и поле Color соответствует 
        /// второму string-параметру. Результат возвращается в виже кортежа
        /// </summary>
        /// <param name="tuple">Tuple(List<Car>,decimal,decimal,string,string)</param>
        /// <returns>Tuple(int,int)</returns>
        static Tuple<int,int>  zadanie7(Tuple<List<Car>, decimal, decimal, string, string> tuple) 
        {
            
            int count_color1 = 0;
            int count_color2 = 0;
            count_color1 = tuple.Item1.Count(c => c.Price >= tuple.Item2 && c.Price <= tuple.Item3 && c.Color == tuple.Item4);
            count_color2 = tuple.Item1.Count(c => c.Price >= tuple.Item2 && c.Price <= tuple.Item3 && c.Color == tuple.Item5);
            return Tuple.Create(count_color1, count_color2);
        }
        static void Main(string[] args)
        {

            List<Car> cars = new List<Car>
            {
                new Car("BMW","X5","black",40000),
                new Car("Lada","2110","green",3500),
                new Car("Lexus","RX350","black",25000),
                new Car("Infinity","FX35","black",42000),
                new Car("Porsche", "Cayenn","white",30000),
                new Car("Porsche","Panamera","gray",80000),
                new Car("Zaz","Forza","red",2000),
                new Car("Daewoo","Nexia","yellow",2000),
                new Car("Toyota","GX470","black",35000),
                new Car("Toyota","Land Cruiser","black",80000)
            };

            WriteLine("Zadanie 1");
            zadanie1(Tuple.Create(cars, 10000m));
            WriteLine();

            WriteLine("Zadanie2");
            zadanie2(Tuple.Create(cars, "red"));
            WriteLine();

            WriteLine("Zadanie3");
            zadanie3(Tuple.Create(cars, 42000m, "Infinity"));
            WriteLine();

            WriteLine("Zadanie4");
            WriteLine(zadanie4(cars));
            WriteLine();

            WriteLine("Zadanie5");
            WriteLine($"Количество авто, соответствующих заданному цвету: {zadanie5(Tuple.Create(cars, "red"))}");
            WriteLine();

            WriteLine("Zadanie6");
            zadanie6(Tuple.Create(cars, 5000m));
            WriteLine();

            WriteLine("Zadanie7");
            Tuple<int, int> tp = zadanie7(Tuple.Create(cars, 30000m, 70000m, "red", "black"));
            WriteLine($"Количество авто красного цвета: {tp.Item1}, черного цвета: {tp.Item2}");

            ReadKey();
        }
    }
}
