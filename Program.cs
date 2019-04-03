using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    class Program
    {
        static void Main(string[] args)
        {
            // Список авиарейсов
            List<Flight> aviaReis = new List<Flight>();

            // Фильтр
            Filter filter = new Filter();
            filter.Init();

            // Бесконечный цикл для главного меню
            while (true)
            {
                // Вывести главное меню
                Console.WriteLine("\t\t Выберите пункт меню: ");
                Console.WriteLine("1.	Ввести в список еще один элемент");
                Console.WriteLine("2.	Вывести весь список. Вывести вместе с полями все элементы.");
                Console.WriteLine("3.	Вывести отфильтрованный список (по умолчанию фильтр пуст).");
                Console.WriteLine("4.	Ввести значения фильтра.");
                Console.WriteLine("5.	Выйти из программы.");

                // Ожидание выбора пользователем пункта в главном меню
                switch (Console.ReadLine())
                {
                    // Обработка выбора пользоветеля
                    case "1":
                        // Ввод нового элемента в список
                        Console.WriteLine("\t\tВвод элемента в список ");
                        Flight.Add(ref aviaReis);
                        break;

                    case "2":
                        // Вывод всего списка
                        Console.WriteLine("\t\tВывод всего списка");
                        Flight.OutAllAvia(ref aviaReis);
                        break;

                    case "3":
                        // Вывод отфильтрованного списка
                        Console.WriteLine("\t\tВывод отфильтрованного списка ");
                        Flight.OutFilterFlight(aviaReis, filter);
                        break;

                    case "4":
                        // Ввод значения фильтра
                        Console.WriteLine("\t\tВвод значения фильтра ");
                        filter.ChangeFilterValues();
                        break;

                    case "5":
                        // Выход
                        System.Environment.Exit(0);
                        break;

                    default:
                        // Пользователь ввёл не то что нужно
                        Console.WriteLine("Введите заного: ");
                        break;
                }
            }
        }
    }

    // Авиарейс
    public struct Flight
    {
        public int Number;             // номер авиарейса
        public DateTime DepartureTime;      // дата и время вылета
        public DateTime ArrivalTime;     // дата и время прибытия
        public string Direction;       // направление
        public string Mark;             // марка самолёта
        public int distance;             // расстояние

        /// <summary>
        /// Инициализация рейса
        /// </summary>
        /// <param name="number"> Номер рейса</param>
        /// <param name="departureTime"> Дата и ремя вылета</param>
        /// <param name="arrivalTime"> Дата и время прилёта</param>
        /// <param name="direction"> Направление</param>
        /// <param name="mark"> Марка самолёта</param>
        /// <param name="distance"> Расстояние</param>
        public Flight(int number, DateTime departureTime, DateTime arrivalTime, string direction, string mark, int distance)
        {
            Number = number;
            Direction = direction;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Mark = mark;
            this.distance = distance;
        }

        // Вывод информацию об одном авиарейсе
        public void OutOneFlight()
        {
            Console.WriteLine("Номер авиарейса: " + Number);
            Console.WriteLine("Дата и время вылета: " + DepartureTime);
            Console.WriteLine("Дата и время прилета: " + ArrivalTime);
            Console.WriteLine("Направление: " + Direction);
            Console.WriteLine("Марка самолёта: " + Mark);
            Console.WriteLine("Расстояние: " + distance);
            Console.WriteLine("_________________________");
        }

        /// <summary>
        /// Вывод всего списка
        /// </summary>
        /// <param name="list"> Список авиарейсов</param>
        public static void OutAllAvia(ref List<Flight> list)
        {
            // Проходимся по каждому эелементу
            foreach (var l in list)
            {
                // Выводим информацию о элементе
                l.OutOneFlight();
            }
        }

        /// <summary>
        /// Добавление нового рейса
        /// </summary>
        /// <param name="list"> Список авиарейса</param>
        public static void Add(ref List<Flight> list)
        {
            try
            {
                // Новый рейс
                Flight fl = new Flight();

                // Номер рейса
                Console.Write("Введите номер авиарейса: ");
                fl.Number = Int32.Parse(Console.ReadLine());

                // Время вылета
                Console.Write("Введите дату и время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS], строго по этому формату : ");
                fl.DepartureTime = DateTime.Parse(Console.ReadLine());

                // Время прилёта
                Console.Write("Введите дату и время прилета в формате [ДД.ММ.ГГГГДД.ММ.ГГГГ HH:MM:SS] строго по этому формату : ");
                fl.ArrivalTime = DateTime.Parse(Console.ReadLine());

                // Направление
                Console.Write("Введите направление ");
                fl.Direction = Console.ReadLine();

                // Марка самолёта
                Console.Write("Введите марку самолёта: ");
                fl.Mark = Console.ReadLine();

                // Расстояние
                Console.Write("Введите расстояние: ");
                fl.distance = Int32.Parse(Console.ReadLine());

                // После того как всё ввели, добавляем рейс к нашему списку
                list.Add(fl);
            }
            catch
            {
                Console.WriteLine("Ошибка добавления! Данные не корректны");
                return;
            }
        }

        /// <summary>
        /// Вывод отфильтрованных рейсов
        /// </summary>
        /// <param name="aviaReis"> Список рейсов</param>
        /// <param name="filter"> Фильтр</param>
        public static void OutFilterFlight(List<Flight> aviaReis, Filter filter)
        {
            // Рассматриваем каждый рейс из списка авиарейсов
            foreach (Flight w in aviaReis) 
            {
                // Проверка минимального номера рейса
                if ((filter.MinNumber != 0) && (w.Number < filter.MinNumber)) continue;

                // Проверка максимального номера рейса
                if ((filter.MaxNumber != 0) && (w.Number > filter.MaxNumber)) continue;

                // Проверка минимального даты и времени вылета
                if ((filter.MinDepartureTime != new DateTime(01,01,01,0,0,0)) && (w.DepartureTime < filter.MinDepartureTime)) continue;

                // Проверка максимального даты и времени вылета
                if ((filter.MinDepartureTime != new DateTime(01, 01, 01, 0, 0, 0)) && (w.DepartureTime < filter.MinDepartureTime)) continue;
               
                // Проверка минимального даты и времени прилёта
                if ((filter.MinDepartureTime != new DateTime(01, 01, 01, 0, 0, 0)) && (w.DepartureTime < filter.MinDepartureTime)) continue;
                
                // Проверка максимального даты и времени прилёта
                if ((filter.MinDepartureTime != new DateTime(01, 01, 01, 0, 0, 0)) && (w.DepartureTime < filter.MinDepartureTime)) continue;

                // Проверка направления
                if (filter.Direction != "" && !w.Direction.Contains(filter.Direction)) continue;
                
                // Проверка марки
                if (filter.Mark != "" && !w.Direction.Contains(filter.Mark)) continue;
               
                // Проверка минимального расстояния
                if ((filter.MinDistance != 0) && (w.distance < filter.MinDistance)) continue;

                // Проверка максимального расстояния
                if ((filter.MaxDistance != 0) && (w.distance > filter.MaxDistance)) continue;
                
                // Вывод отфильтрованного рейса на экран
                w.OutOneFlight(); 
            }
        }
    }

    // Фильтр
    public struct Filter
    {
        public int MinNumber;                         // Минимальный номер рейса
        public int MaxNumber;                         // Максимальный номер рейса
        public DateTime MinDepartureTime;             // Минимальное дата и время вылета
        public DateTime MaxDepartureTime;             // Максимальное дата и время вылета
        public DateTime MinArrivalTime;               // Минимальное дата и время прилета
        public DateTime MaxArrivalTime;               // Максимальное дата и время прилета
        public string Direction;                      // Направление
        public string Mark;                           // Марка
        public int MinDistance;                       // Минимальное расстояние полёта
        public int MaxDistance;                       // Максимальное расстояние полёта
        
        // Инициализация фильтра
        public void Init()
        {
            MinNumber = 0;
            MaxNumber = 0;
            Direction="";
            Mark = "";
            MinDepartureTime = MaxDepartureTime =new DateTime(01, 01, 01, 0, 0, 0);
            MinArrivalTime = MaxArrivalTime = new DateTime(01, 01, 01, 0, 0, 0);
            MaxDistance = 0;
        }

        /// <summary>
        /// Ввести целое значение
        /// </summary>
        /// <param name="write"> Сообщение на экран</param>
        /// <returns> Введенное значение</returns>
        public int InputIntValue(string write)
        {
            while (true)
            {
                try
                {
                    Console.Write(write);
                    int value = Int32.Parse(Console.ReadLine().Trim());
                    return value;
                }
                catch
                {
                    Console.WriteLine("Ошибка: неверный формат");
                }
            }
        }

        /// <summary>
        /// Ввести дату и время
        /// </summary>
        /// <param name="write"> Сообщение на экран</param>
        /// <returns> Введенная дата и время</returns>
        public DateTime InputDateTime(string write)
        {
            while (true)
            {
                try
                {
                    Console.Write(write);
                    DateTime value = DateTime.Parse(Console.ReadLine());
                    return value;
                }
                catch
                {
                    Console.WriteLine("Ошибка: неверный формат");
                }
            }

        }

        // Изменить значение фильтра
        public void ChangeFilterValues()
        {
            // Вывод меню полей фильтра 
            Console.WriteLine("\t\tВыберите какое поле фильтра изменить:");
            Console.WriteLine($"1. Минимальный номер рейса ({MinNumber})");
            Console.WriteLine($"2. Максимальный номер рейса ({MaxNumber})");
            Console.WriteLine($"3. Минимальная длительность вылета ({MinDepartureTime})");
            Console.WriteLine($"4. Максимальная длительность вылёта ({MaxDepartureTime})");
            Console.WriteLine($"5. Минимальная длительность прилёта ({MinArrivalTime})");
            Console.WriteLine($"6. Максимальная длительность прилёта ({MaxArrivalTime})");
            Console.WriteLine($"7. Направление ({Direction})");
            Console.WriteLine($"8. Марка ({Mark})");
            Console.WriteLine($"9. Минимальное расстояние полёта ({MinDistance})");
            Console.WriteLine($"10. Максимальное расстояние полёта ({MaxDistance})");

            // Ожидание ввода пользователя и обработка
            switch (Console.ReadLine().Trim())
            {
                case "1": // Вводим минимальный номер рейса
                    MinNumber = InputIntValue("Введите минимальный номер рейса:");
                    break;

                case "2": // Вводим максимальный номер рейса
                    MaxNumber = InputIntValue("Введите максимальный номер рейса:");
                    break;

                case "3": // Вводим минимальную дату и время вылета рейса
                    MinDepartureTime = InputDateTime("Введите минимальную дату и время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS]");
                    break;

                case "4": // Вводим максимальную дату и время вылета рейса
                    MaxDepartureTime = InputDateTime("Введите максимальную дату и время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS]");
                    break;

                case "5": // Вводим минимальную дату и время прилёта рейса
                    MinArrivalTime = InputDateTime("Введите максимальную дату и время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS]");
                    break;

                case "6": // Вводим максимальную дату и время прилёта рейса
                    MaxArrivalTime = InputDateTime("Введите максимальную дату и время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS]");
                    break;

                case "7": // Вводим напрвление
                    Console.WriteLine("Введите направление рейса:");
                    Direction = Console.ReadLine().Trim();
                    break;

                case "8": // Вводим марку
                    Console.WriteLine("Введите марку самолёта:");
                    Mark = Console.ReadLine().Trim();
                    break;

                case "9": // Вводим минимальное расстояние рейса
                    MinDistance = InputIntValue("Введите минимальное расстояние:");
                    break;

                case "10": // Вводим максимальное расстояние рейса
                    MaxDistance = InputIntValue("Введите максимальное расстояние:");
                    break;
            }
        }
    }
}