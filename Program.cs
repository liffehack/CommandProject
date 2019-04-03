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
            List<AviaReis> aviaReis = new List<AviaReis>();

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
                        AviaReis.AddFlight(ref aviaReis);
                        break;

                    case "2":
                        // Вывод всего списка
                        Console.WriteLine("\t\tВывод всего списка");
                        AviaReis.Out_All_Flight(ref aviaReis);
                        break;

                    case "3":
                        // Вывод отфильтрованного списка
                        Console.WriteLine("\t\tВывод отфильтрованного списка ");
                        AviaReis.OutFilterAvia(aviaReis, filter);
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
    public struct AviaReis
    {
        public int num_reis;             // номер авиарейса
        public DateTime time_start;      // дата и время вылета
        public DateTime time_finish;     // дата и время прибытия
        public string napravlenie;       // направление
        public string marka;             // марка самолёта
        public int distance;             // расстояние

        /// <summary>
        /// Инициализация рейса
        /// </summary>
        /// <param name="NUM_R"> Номер рейса</param>
        /// <param name="TIME_START"> Время вылета</param>
        /// <param name="TIME_FINISH"> Время прилёта</param>
        /// <param name="NAPRAVLENIE"> Направление</param>
        /// <param name="MARKA"> Марка самолёта</param>
        /// <param name="DISTANCE"> Расстояние</param>
        public AviaReis(int NUM_R, DateTime TIME_START, DateTime TIME_FINISH, string NAPRAVLENIE, string MARKA, int DISTANCE)
        {
            num_reis = NUM_R;
            napravlenie = NAPRAVLENIE;
            time_start = TIME_START;
            time_finish = TIME_FINISH;
            marka = MARKA;
            distance = DISTANCE;
        }

        // Вывод информацию об одном авиарейсе
        public void Out_One_Flight()
        {
            Console.WriteLine("Номер авиарейса: " + num_reis);
            Console.WriteLine("Время вылета: " + time_start);
            Console.WriteLine("Время прилета: " + time_finish);
            Console.WriteLine("Направление: " + napravlenie);
            Console.WriteLine("Марка самолёта: " + marka);
            Console.WriteLine("Расстояние: " + distance);
            Console.WriteLine("_________________________");
        }

        /// <summary>
        /// Вывод всего списка
        /// </summary>
        /// <param name="list"> Список авиарейсов</param>
        public static void Out_All_Flight(ref List<AviaReis> list)
        {
            // Проходимся по каждому эелементу
            foreach (var l in list)
            {
                // Выводим информацию о элементе
                l.Out_One_Flight();
            }
        }

        /// <summary>
        /// Добавление нового рейса
        /// </summary>
        /// <param name="list"> Список авиарейса</param>
        public static void AddFlight(ref List<AviaReis> list)
        {
            try
            {
                // Новый рейс
                AviaReis fl = new AviaReis();
                Console.Write("Введите номер авиарейса: ");
                fl.num_reis = Int32.Parse(Console.ReadLine());
                Console.Write("Введите время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS], строго по этому формату : ");
                fl.time_start = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите время прилета в формате [ДД.ММ.ГГГГДД.ММ.ГГГГ HH:MM:SS] строго по этому формату : ");
                fl.time_finish = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите направление ");
                fl.napravlenie = Console.ReadLine();
                Console.Write("Введите марку самолёта: ");
                fl.marka = Console.ReadLine();
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
        /// Получить длительность полёта в секундах
        /// </summary>
        /// <returns> Длительность полёта в секундах</returns>
        public int Get_length_seconds()
        {
            int lentgh = 0; // длительность
            TimeSpan rez = time_finish - time_start; // Разница времени прилёта от вылета
            lentgh = rez.Hours*60*60+ rez.Minutes*60 + rez.Seconds; // Получаем разницу в секундах
            return lentgh;
        }

        /// <summary>
        /// Вывод отфильтрованных рейсов
        /// </summary>
        /// <param name="aviaReis"> Список рейсов</param>
        /// <param name="filter"> Фильтр</param>
        public static void OutFilterAvia(List<AviaReis> aviaReis, Filter filter)
        {
            // Рассматриваем каждый рейс из списка авиарейсов
            foreach (AviaReis w in aviaReis) 
            {
                // Проверка минимального номера рейса
                if ((filter.min_num_reis != 0) && (w.num_reis < filter.min_num_reis)) continue;

                // Проверка максимального номера рейса
                if ((filter.max_num_reis != 0) && (w.num_reis > filter.max_num_reis)) continue;

                // Проверка минимальной длительности полёта
                if ((filter.Get_Min_Length() != 0) && (w.Get_length_seconds() < filter.Get_Min_Length())) continue;

                // Проверка максимальной длительности полёта
                if ((filter.Get_Max_Length() != 0) && (w.Get_length_seconds() > filter.Get_Max_Length())) continue;

                // Проверка направления
                if (filter.napravlenie != "" && !w.napravlenie.Contains(filter.napravlenie)) continue;
                
                // Проверка марки
                if (filter.marka != "" && !w.napravlenie.Contains(filter.marka)) continue;
               
                // Проверка минимального расстояния
                if ((filter.min_distance != 0) && (w.distance < filter.min_distance)) continue;

                // Проверка максимального расстояния
                if ((filter.max_distance != 0) && (w.distance > filter.max_distance)) continue;

                w.Out_One_Flight(); // Вывод отфильтрованного рейса на экран
            }
        }
    }

    // Фильтр
    public struct Filter
    {
        public int min_num_reis;                        // Минимальный номер рейса
        public int max_num_reis;                        // Максимальный номер рейса
        public int min_hours, min_minutes, min_seconds; // Минимальная длительность полёта: часы, минуты, секунда
        public int max_hours, max_minutes, max_seconds; // Максимальная длительность полёта: часы, минуты, секунда
        public string napravlenie;                      // Направление
        public string marka;                            // Марка
        public int min_distance;                        // Минимальное расстояние полёта
        public int max_distance;                        // Максимальное расстояние полёта
        
        // Инициализация фильтра
        public void Init()
        {
            min_num_reis = 0;
            max_num_reis = 0;
            min_hours = min_minutes = min_seconds = 0;
            max_hours = max_minutes = max_seconds = 0;
            napravlenie="";
            marka = "";
            min_distance = 0;
            max_distance = 0;
        }

        /// <summary>
        /// Получить минимальную длительность полёта в секундах
        /// </summary>
        /// <returns> Минимальная длительность полёта в секундах</returns>
        public int Get_Min_Length()
        {
            int length = min_hours * 60 * 60 + min_minutes * 60 + min_seconds; // Минимальная длительность полёта в секундах
            return length;
        }

        /// <summary>
        /// Получить максимальную длительность полёта в секундах
        /// </summary>
        /// <returns> Минимальная длительность полёта в секундах</returns>
        public int Get_Max_Length()
        {
            int length = max_hours * 60 * 60 + max_minutes * 60 + max_seconds; // Максимальная длительность полёта в секундах
            return length;
        }

        // Изменить значение фильтра
        public void ChangeFilterValues()
        {
            // Вывод меню полей фильтра 
            Console.WriteLine("\t\tВыберите какое поле фильтра изменить:");
            Console.WriteLine($"1. Минимальный номер рейса ({min_num_reis})");
            Console.WriteLine($"2. Максимальный номер рейса ({max_num_reis})");
            Console.WriteLine($"3. Минимальная длительность полёта ({min_hours}:{min_minutes}:{min_seconds})");
            Console.WriteLine($"3. Минимальная длительность полёта ({max_hours}:{max_minutes}:{max_seconds})");
            Console.WriteLine($"5. Направление ({napravlenie})");
            Console.WriteLine($"6. Марка ({marka})");
            Console.WriteLine($"7. Минимальное расстояние полёта ({min_distance})");
            Console.WriteLine($"8. Максимальное расстояние полёта ({max_distance})");

            // Считываем выбранный пункт
            char ch = char.Parse(Console.ReadLine());

            // Ожидание ввода пользователя и обработка
            switch (ch)
            {
                // Изменение значения фильтра по имени
                case '1': // Вводим минимальный номер рейса
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите минимальный номер рейса:");
                            min_num_reis = Int32.Parse(Console.ReadLine().Trim());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: неверный формат");
                        }
                    }
                    break;
                   

                case '2': // Вводим максимальный номер рейса
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите максимальный номер рейса:");
                            min_num_reis = Int32.Parse(Console.ReadLine().Trim());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: неверный формат");
                        }
                    }
                    break;

                case '3': // Вводим минимальную длительность полёта рейса
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите минимальную длительность полёта:");
                            Console.Write("Часы: ");
                            min_hours = Int32.Parse(Console.ReadLine().Trim());
                            Console.Write("Минуты: ");
                            min_minutes = Int32.Parse(Console.ReadLine().Trim()); 
                            Console.Write("Секунды: ");
                            min_seconds = Int32.Parse(Console.ReadLine().Trim());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: неверный формат");
                        }
                    }
                    break;

                case '4': // Вводим максимальную длительность полёта рейса
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите максимальную длительность полёта:");
                            Console.Write("Часы: ");
                            max_hours = Int32.Parse(Console.ReadLine().Trim());
                            Console.Write("Минуты: ");
                            max_minutes = Int32.Parse(Console.ReadLine().Trim());
                            Console.Write("Секунды: ");
                            max_seconds = Int32.Parse(Console.ReadLine().Trim());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: неверный формат");
                        }
                    }
                    break;

                case '5': // Вводим направление рейса
                    Console.WriteLine("Введите направление рейса:");
                    napravlenie = Console.ReadLine().Trim();
                    break;

                case '6': // Вводим марку рейса
                    Console.WriteLine("Введите марку самолёта:");
                    marka = Console.ReadLine().Trim();
                    break;

                case '7': // Вводим минимальное расстояние рейса
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите минимальное расстояние полёта:");
                            min_distance = Int32.Parse(Console.ReadLine().Trim());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: неверный формат");
                        }
                    }
                    break;

                case '8': // Вводим максимальное расстояние рейса
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите максимальное расстояние полёта:");
                            max_distance = Int32.Parse(Console.ReadLine().Trim());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: неверный формат");
                        }
                    }
                    break;
            }
        }
    }
}
