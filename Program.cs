using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Program
{
    class Program
    {
        #region Объявление перечиления marks

        enum marks { AIRBIS, BOEING, IL96};

        #endregion

        // Структура "Авиарейсы"
        public class Flight
        {
            private int num_r;            // номер авиарейса
            private DateTime time_start;  // время вылета
            private DateTime time_finish; // время прибытия
            private string napravlenie;   // направление
            private string marka;         // марка самолёта
            private int distance;         // расстояние
            public Flight() { }

            //Конструктор для инициализации
            public Flight(int NUM_R,  DateTime TIME_START, DateTime TIME_FINISH, string NAPRAVLENIE, string MARKA, int DISTANCE)
                {
                num_r=NUM_R;
                napravlenie = NAPRAVLENIE;
                time_start = TIME_START;
                time_finish = TIME_FINISH;
                marka = MARKA;
                distance = DISTANCE;
                }

            //Метод для вывода данных объекта структуры
            public void print_all()
            {
                Console.WriteLine("Номер авиарейса: " + num_r );
                Console.WriteLine("Время вылета: " + time_start);
                Console.WriteLine("Время прилета: " + time_finish);
                Console.WriteLine("Направление: " + napravlenie);
                Console.WriteLine("Марка самолёта: " + marka);
                Console.WriteLine("Расстояние: " + distance);
                Console.WriteLine("_________________________");
            }

            //Метод для вывода всех рейсов
            public static void WriteAllFlight(ref List<Flight> list)
            {
                Console.Clear();
                foreach (var l in list)
                {
                    l.print_all();
                }
            }

            //Метод для добавления новых рейсов
            public static void AddFlight(ref List<Flight> list)
            {
                Console.Clear();
                Console.Write("Введите номер авиарейса: ");
                Console.Write("Введите время вылета в формате ДД.ММ.ГГГГ : ");
                Console.Write("Введите время прилета в формате ДД.ММ.ГГГГ : ");
                Console.Write("Введите направление ");
                Console.Write("Введите марку самолёта: ");
                Console.Write("Введите расстояние: ");
            }


        }

        
            

        static void Main(string[] args)
        {   
            //Создаем список структуры авиарейса
            List<Flight> list = new List<Flight>();
            //Заполняем список
            list.Add(new Flight(1, new DateTime(2015, 7, 20), new DateTime(2015, 7, 21), "Moscow->Cheb", "CHINA", 1000));
            list.Add(new Flight(2, new DateTime(2015, 7, 22), new DateTime(2015, 7, 23), "Cheb->Moscow", "CHINA", 1000));
            list.Add(new Flight(3, new DateTime(2015, 7, 24), new DateTime(2015, 7, 25), "Moscow->Kazan", "CHINA", 1200));
            list.Add(new Flight(4, new DateTime(2015, 7, 26), new DateTime(2015, 7, 27), "Kazan->Moscow", "CHINA", 1200));
            list.Add(new Flight(5, new DateTime(2015, 7, 28), new DateTime(2015, 7, 29), "Kazan->Cheb", "CHINA", 200));
            list.Add(new Flight(6, new DateTime(2015, 7, 30), new DateTime(2015, 7, 31), "Cheb->Kazan", "CHINA", 200));
            Console.WriteLine("\t\t Выберите пункт меню: ");
            Console.WriteLine("1.	Ввести в список еще один элемент");
            Console.WriteLine("2.	Вывести весь список. Вывести вместе с полями все элементы.");
            Console.WriteLine("3.	Вывести отфильтрованный список.(по умолчанию фильтр пуст).");
            Console.WriteLine("4.	Ввести значения фильтра.");
            Console.WriteLine("5.	Выйти из программы.");
            //Запускаем цикл, чтобы пользователь мог выбрать пункты
            while (true)
            {
                //Реакция системы на клавиатуры
                switch (Console.ReadLine()){
                    case "1": Console.WriteLine("\t\tВвод элемента в список ");  break;
                    case "2": Console.WriteLine("\t\tВывод всего списка");
                        Flight.WriteAllFlight(ref list);
                            break;
                    case "3": Console.WriteLine("\t\tВывод отфильтрованного списка "); break;
                    case "4": Console.WriteLine("\t\tВвод значения фильтра "); break;
                    case "5":
                        System.Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Введите заного: "); break;
                }
            }
        }
    }
}