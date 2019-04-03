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
                        AviaReis.AddAvia(ref aviaReis);
                        break;

                    case "2":
                        // Вывод всего списка
                        Console.WriteLine("\t\tВывод всего списка");
                        AviaReis.OutAllAvia(ref aviaReis);
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
        public void OutOneAvia()
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
        public static void OutAllAvia(ref List<AviaReis> list)
        {
            // Проходимся по каждому эелементу
            foreach (var l in list)
            {
                // Выводим информацию о элементе
                l.OutOneAvia();
            }
        }

        /// <summary>
        /// Добавление нового рейса
        /// </summary>
        /// <param name="list"> Список авиарейса</param>
        public static void AddAvia(ref List<AviaReis> list)
        {
            try
            {
                // Новый рейс
                AviaReis fl = new AviaReis();

                // Номер рейса
                Console.Write("Введите номер авиарейса: ");
                fl.num_reis = Int32.Parse(Console.ReadLine());

                // Время вылета
                Console.Write("Введите время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS], строго по этому формату : ");
                fl.time_start = DateTime.Parse(Console.ReadLine());

                // Время прилёта
                Console.Write("Введите время прилета в формате [ДД.ММ.ГГГГДД.ММ.ГГГГ HH:MM:SS] строго по этому формату : ");
                fl.time_finish = DateTime.Parse(Console.ReadLine());

                // Направление
                Console.Write("Введите направление ");
                fl.napravlenie = Console.ReadLine();

                // Марка самолёта
                Console.Write("Введите марку самолёта: ");
                fl.marka = Console.ReadLine();

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
        /// Получить длительность полёта в секундах
        /// </summary>
        /// <returns> Длительность полёта в секундах</returns>
        public int GetLengthAvia()
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
                if ((filter.GetLengthFilter(true) != 0) && (w.GetLengthAvia() < filter.GetLengthFilter(true))) continue;

                // Проверка максимальной длительности полёта
                if ((filter.GetLengthFilter(false) != 0) && (w.GetLengthAvia() > filter.GetLengthFilter(false))) continue;

                // Проверка направления
                if (filter.napravlenie != "" && !w.napravlenie.Contains(filter.napravlenie)) continue;
                
                // Проверка марки
                if (filter.marka != "" && !w.napravlenie.Contains(filter.marka)) continue;
               
                // Проверка минимального расстояния
                if ((filter.min_distance != 0) && (w.distance < filter.min_distance)) continue;

                // Проверка максимального расстояния
                if ((filter.max_distance != 0) && (w.distance > filter.max_distance)) continue;
                
                // Вывод отфильтрованного рейса на экран
                w.OutOneAvia(); 
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
        /// Получить длительность фильтра
        /// </summary>
        /// <param name="Min"> Флаг: минимальная или максимальная длительность </param>
        /// <returns>Длительность полёта</returns>
        public int GetLengthFilter(bool Min)
        {
            // Длительность
            int length = 0;

            // Проверка на минимальность длительности
            if (Min)
                length = min_hours * 60 * 60 + min_minutes * 60 + min_seconds;
            else
                length = max_hours * 60 * 60 + max_minutes * 60 + max_seconds;

            // Возвращаем длительность полёта
            return length;
        }

        /// <summary>
        /// Ввести целое значение
        /// </summary>
        /// <param name="write"> Сообщение</param>
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
                    min_num_reis = InputIntValue("Введите минимальный номер рейса:");
                    break;

                case '2': // Вводим максимальный номер рейса
                    max_num_reis = InputIntValue("Введите максимальный номер рейса:");
                    break;

                case '3': // Вводим минимальную длительность полёта рейса
                    min_hours = InputIntValue("Часы < 24, строго!:");
                    min_minutes = InputIntValue("Минуты <60, строго!:");
                    min_seconds = InputIntValue("Секунды <60, строго!:");
                    break;

                case '4': // Вводим максимальную длительность полёта рейса
                    max_hours = InputIntValue("Часы < 24, строго!:");
                    max_minutes = InputIntValue("Минуты <60, строго!:");
                    max_seconds = InputIntValue("Секунды <60, строго!:");
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
                    min_distance = InputIntValue("Введите минимальное расстояние:");
                    break;

                case '8': // Вводим максимальное расстояние рейса
                    max_distance = InputIntValue("Введите максимальное расстояние:");
                    break;
            }
        }
    }
}
