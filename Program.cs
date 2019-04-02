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
        static void Main(string[] args)
        {
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
                        Flight.AddFlight(ref list);
                        break;

                    case "2":
                        // Вывод всего списка
                        Console.WriteLine("\t\tВывод всего списка");
                        Flight.Out_All_Flight(ref list);
                        break;

                    case "3":
                        // Вывод отфильтрованного списка
                        Console.WriteLine("\t\tВывод отфильтрованного списка ");
                        PrintFilteredOut(list, filtr);
                        break;

                    case "4":
                        // Ввод значения фильтра
                        Console.WriteLine("\t\tВвод значения фильтра ");
                        Console.WriteLine(filtr.InputFilterValues());
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

        // Список всех авиарейсов
        static List<Flight> list = new List<Flight>(); 
        
        // Значения фильтра
        static Filter filtr = new Filter();                

        // Авиарейс
        public struct Flight
        {
            public int num_flight;           // номер авиарейса
            public DateTime time_start;      // время вылета
            public DateTime time_finish;     // время прибытия
            public string napravlenie;       // направление
            public string marka;             // марка самолёта
            public int distance;             // расстояние

            /// <summary>
            /// Инициализация рейса
            /// </summary>
            /// <param name="NUM_R">Номер рейса</param>
            /// <param name="TIME_START">Время вылета</param>
            /// <param name="TIME_FINISH">Время прилёта</param>
            /// <param name="NAPRAVLENIE">Направление</param>
            /// <param name="MARKA">Марка самолёта</param>
            /// <param name="DISTANCE">Расстояние</param>
            public Flight(int NUM_R, DateTime TIME_START, DateTime TIME_FINISH, string NAPRAVLENIE, string MARKA, int DISTANCE)
            {
                num_flight = NUM_R;
                napravlenie = NAPRAVLENIE;
                time_start = TIME_START;
                time_finish = TIME_FINISH;
                marka = MARKA;
                distance = DISTANCE;
            }

            // Вывод информацию об одном авиарейсе
            public void Out_Flight_Info()
            {
                Console.WriteLine("Номер авиарейса: " + num_flight);
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
            /// <param name="list">Список авиарейсов</param>
            public static void Out_All_Flight(ref List<Flight> list)
            {
                // Проходимся по каждому эелементу
                foreach (var l in list)
                {
                    // Выводим информацию о элементе
                    l.Out_Flight_Info();
                }
            }

            /// <summary>
            /// Добавление нового рейса
            /// </summary>
            /// <param name="list">Список авиарейса</param>
            public static void AddFlight(ref List<Flight> list)
            {
                //Элемент для добавления
                Flight fl = new Flight();
                Console.Write("Введите номер авиарейса: ");
                fl.num_flight = Int32.Parse(Console.ReadLine());
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

            /// <summary>
            /// Получить длительность полёта в секундах
            /// </summary>
            /// <returns>Длительность полёта в секундах</returns>
            public int Get_length_seconds()
            {
               
                int lentgh = 0; // длительность
                TimeSpan rez= time_finish - time_start; // Разница времени прилёта от вылета
                lentgh = rez.Seconds; // Получаем разницу в секундах
                return lentgh;   
            }
        }

        // Фильтр
        public struct Filter
        {
            public string min_num_flight;                  // минимальный номер авиарейса
            public string max_num_flight;                  // максимальный момер авиарейса
            public string time_start_vilet;                // Дата вылета, начало
            public string time_finish_vilet;               // Дата вылета, конец
            public string time_start_prilet;               // Дата прилёта, начало
            public string time_finish_prilet;              // Дата прилёта, конец
            public string napravlenie;                     // направление
            public string marka;                           // марка самолёта
            public string min_distance;                    // минимальное расстояние
            public string max_distance;                    // максимальное расстояние
            public int number_filter;                      // Номер фильтрации

            /// <summary>
            /// Ввод значений фильтра
            /// </summary>
            /// <returns>Номер фильтрации</returns>
            public int InputFilterValues()
            {
                // Вывод меню полей фильтра
                Console.WriteLine("Поле фильтра для ввода значения: ");
                Console.WriteLine("1.Диапазон номера авиарейса");
                Console.WriteLine("2.Диапазон времени вылета");
                Console.WriteLine("3.Диапазон времени прилёта");
                Console.WriteLine("4.Направление");
                Console.WriteLine("5.Марка");
                Console.WriteLine("6.Диапазон расстояния");

                // Считываем выбранный пункт
                switch (Console.ReadLine())
                {
                    case "1":
                        // Вводим диапазон номера
                        Console.WriteLine("Минимальный номер рейса:");
                        min_num_flight = Console.ReadLine();
                        Console.WriteLine("Максимальный номер рейса");
                        max_num_flight = Console.ReadLine();

                        // Если минимальное значение номера авиарейса для фильтра не указано
                        if (this.min_num_flight == "")
                        {
                            if (this.max_num_flight == "")
                                number_filter = 0; // Фильтрация по умолчанию
                            else number_filter = 2; // Проводим фильтрацию только по макс. номеру
                        }
                        else
                        {
                            if (this.max_num_flight != "")
                                number_filter = 3; // Проводим фмльтрацию и по макс. и по мин. номеру
                            else number_filter = 1; // Проводим фильтрацию только по мин. номеру

                        }
                        break;

                    case "2":
                        // Вводим диапазон даты и времени вылета
                        Console.WriteLine("Минимальная дата вылета в формате [ДД.ММ.ГГГГ HH:MM:SS], строго!!:");
                        time_start_vilet = Console.ReadLine(); 
                        Console.WriteLine("Максимальная дата вылета в формате [ДД.ММ.ГГГГ HH:MM:SS], строго!!:");
                        time_finish_vilet = Console.ReadLine();

                        // Если минимальное значение даты вылета авиарейса для фильтра не указано
                        if (this.time_start_vilet == "")
                        {
                            if (this.time_finish_vilet == "")
                                number_filter = 0;  // Проводим фильтрацию по умолчанию
                            else number_filter = 5; // Проводим фильтрацию только по макс. дате вылета
                        }
                        else
                        {
                            if (this.time_finish_vilet != "")
                                number_filter = 6; // Проводим фмльтрацию и по макс. и по мин. дате вылета
                            else number_filter = 4; // Проводим фильтрацию только по мин. дате вылета

                        }
                        break;

                    case "3":
                        // Вводим диапазон даты и времени прилёта
                        Console.WriteLine("Минимальная дата прилёта в формате [ДД.ММ.ГГГГ HH:MM:SS], строго!!:");
                        time_start_prilet = Console.ReadLine();
                        Console.WriteLine("Максимальная дата прилёта в формате [ДД.ММ.ГГГГ HH:MM:SS], строго!!:");
                        time_finish_prilet = Console.ReadLine();

                        // Если минимальное значение даты прилета авиарейса для фильтра не указано
                        if (this.time_start_prilet == "")
                        {
                            if (this.time_finish_prilet == "")
                                number_filter = 0;  // Проводим фильтрацию по умолчанию
                            else number_filter = 8; // Проводим фильтрацию только по макс. дате прилёта
                        }
                        else
                        {
                            if (this.time_finish_prilet != "")
                                number_filter = 9; // Проводим фмльтрацию и по макс. и по мин. дате прилёта
                            else number_filter = 7; // Проводим фильтрацию только по мин. дате прилёта

                        }
                        break;

                    case "4":
                        // Вводим значение для направления
                        Console.WriteLine("Направление: ");
                        napravlenie = Console.ReadLine();

                        // Если  значение направления авиарейса для фильтра не указано
                        if (napravlenie == "")
                            number_filter = 0;
                        else number_filter = 10; // Проводим фильтрацию по направлению
                        break;

                    case "5":
                        // Вводим значение для марки
                        Console.WriteLine("Марка: ");
                        marka = Console.ReadLine();

                        // Если  значение марки самолёта для фильтра не указано
                        if (marka == "")
                            number_filter = 0;
                        else number_filter = 11; // Проводим фильтрацию по марке
                        break;

                    case "6":
                        // Вводим диапазон для расстояния
                        Console.WriteLine("Минимальное расстояние: ");
                        min_distance = Console.ReadLine();
                        Console.WriteLine("Максимальное расстояние: ");
                        max_distance = Console.ReadLine();

                        // Если минимальное значение расстояния полёта не указано
                        if (this.min_distance == "")
                        {
                            if (this.max_distance == "")
                                number_filter = 0;
                            else number_filter = 13; // Проводим фильтрацию только по макс. расстоянию
                        }
                        else
                        {
                            if (this.max_distance != "")
                                number_filter = 14; // Проводим фмльтрацию и по макс. и по мин. расстоянию
                            else number_filter = 12; // Проводим фильтрацию только по мин. расстоянию

                        }
                        break;

                    default:
                        // Пользователь ввёл не то что нужно
                        number_filter = 0; 
                        break;
                }
                return number_filter;
            }
        }

        /// <summary>
        /// Вывод отфильтрованного списка
        /// </summary>
        /// <param name="list">Список авиарейсов</param>
        /// <param name="filtr">Параметры фильтра, по которому происходит фильтрация</param>
        static public void PrintFilteredOut(List<Flight> list, Filter filtr)
        {
            // Выбор необходимой нам фильтрации
            switch(filtr.number_filter)
            {
                // В зависимости от того, какую фильтрацию нужно произвести, делаем обработку
                case 0:
                    // Вывести весь список авиарейса, фильтр пуст
                    Console.WriteLine("Вывести весь список авиарейса, фильтр пуст");
                    foreach (Flight w in list)
                    {
                        w.Out_Flight_Info();
                    }
                    break;

                case 1:
                    // Вывести список, номер авиарейса которого не меньше указанного номера
                    Console.WriteLine("Вывести список, номер авиарейса которого не меньше указанного номера");
                    foreach (Flight w in list)
                    {
                        if (w.num_flight > Int32.Parse(filtr.min_num_flight))
                            w.Out_Flight_Info();
                    }
                    break;

                case 2:
                    // Вывести список, номер авиарейса которого не больше указанного номера
                    Console.WriteLine("Вывести список, номер авиарейса которого не больше указанного номера");
                    foreach (Flight w in list)
                    {
                        if (w.num_flight < Int32.Parse(filtr.max_num_flight))
                            w.Out_Flight_Info();
                    }
                    break;

                case 3:
                    // Вывести список, номер авиарейса которого находится в указанной нами промежутке
                    Console.WriteLine("Вывести список, номер авиарейса которого находится в указанной нами промежутке");
                    foreach (Flight w in list)
                    {
                        if ((w.num_flight > Int32.Parse(filtr.min_num_flight)) && (w.num_flight < Int32.Parse(filtr.max_num_flight)))
                            w.Out_Flight_Info();
                    }
                    break;

                case 4:
                    // Вывести список, дата вылета которых не меньше заданной даты вылета авиарейса
                    Console.WriteLine("Вывести список, дата вылета которых не меньше заданной даты вылета авиарейса ");
                    foreach (Flight w in list)
                    {
                        if (w.time_start > DateTime.Parse(filtr.time_start_vilet))
                            w.Out_Flight_Info();
                    }
                    break;

                case 5:
                    // Вывести список, дата вылета которых не больше заданной даты вылета авиарейсаа
                    Console.WriteLine("Вывести список, дата вылета которых не больше заданной даты вылета авиарейса");
                    foreach (Flight w in list)
                    {
                        if (w.time_start < DateTime.Parse(filtr.time_finish_vilet))
                            w.Out_Flight_Info();
                    }
                    break;

                case 6:
                    // Вывести список в заданном интервале даты вылета авиарейса
                    Console.WriteLine("Вывести список в заданном интервале даты вылета авиарейса");
                    foreach (Flight w in list)
                    {
                        if ((w.time_start > DateTime.Parse(filtr.time_start_vilet))&&(w.time_start < DateTime.Parse(filtr.time_finish_vilet)))
                            w.Out_Flight_Info();
                    }
                    break;

                case 7:
                    // Вывести список, дата прилёта которых не меньше заданной даты прилёта авиарейса
                    Console.WriteLine("Вывести список, дата прилёта которых не меньше заданной даты прилёта авиарейса");
                    foreach (Flight w in list)
                    {
                        if (w.time_finish > DateTime.Parse(filtr.time_start_prilet))
                            w.Out_Flight_Info();
                    }
                    break;

                case 8:
                    // Вывести список, дата прилёта которых не больше заданной даты прилёта авиарейса
                    Console.WriteLine("Вывести список, дата прилёта которых не больше заданной даты прилёта авиарейса");
                    foreach (Flight w in list)
                    {
                        if (w.time_finish < DateTime.Parse(filtr.time_finish_prilet))
                            w.Out_Flight_Info();
                    }
                    break;

                case 9:
                    // Вывести список в заданном интервале даты прилёта авиарейса
                    Console.WriteLine("Вывести список в заданном интервале даты прилёта авиарейса");
                    foreach (Flight w in list)
                    {
                        if ((w.time_finish > DateTime.Parse(filtr.time_start_prilet)) && (w.time_finish < DateTime.Parse(filtr.time_finish_prilet)))
                            w.Out_Flight_Info();
                    }
                    break;

                case 10:
                    // Вывести список, с заданным направлением
                    Console.WriteLine("Вывести список, с заданным направлением");
                    foreach (Flight w in list)
                    {
                        if (w.napravlenie == filtr.napravlenie)
                            w.Out_Flight_Info();
                    }
                    break;

                case 11:
                    // Вывести список, с заданной маркой
                    Console.WriteLine("Вывести список, с заданной маркой");
                    foreach (Flight w in list)
                    {
                        if (w.marka == filtr.marka)
                            w.Out_Flight_Info();
                    }
                    break;

                case 12:
                    // Вывести список, с минимальным расстоянием полёта авиарейса
                    Console.WriteLine("Вывести список, с минимальным расстоянием полёта авиарейса");
                    foreach (Flight w in list)
                    {
                        if (w.distance > Int32.Parse(filtr.min_distance))
                            w.Out_Flight_Info();
                    }
                    break;

                case 13:
                    // Вывести список, с максимальным расстоянием полёта авиарейса
                    Console.WriteLine("Вывести список, с максимальным расстоянием полёта авиарейса");
                    foreach (Flight w in list)
                    {
                        if (w.distance < Int32.Parse(filtr.max_distance))
                            w.Out_Flight_Info();
                    }
                    break;

                case 14:
                    // Вывести список, в интервале заданного расстояния авиарейса
                    Console.WriteLine("Вывести список, в интервале заданного расстояния авиарейса");
                    foreach (Flight w in list)
                    {
                        if ((w.distance > Int32.Parse(filtr.min_distance)) && (w.distance < Int32.Parse(filtr.max_distance)))
                            w.Out_Flight_Info();
                    }
                    break;

                case 15:
                    // Вывести рейс с макимальной длительностью полёта
                    Console.WriteLine("Авиарейс с максимальной длительностью полёта");
                    int maxlength=0; // максимальная длительность полёта из списка авиарейса

                    // Найдём максимальную длительность полёта
                    foreach (Flight w in list)
                    {
                        // если длительносить рейса больше предыдущего то обновляем макс. длительность
                        if (w.Get_length_seconds() > maxlength)
                        {
                            maxlength = w.Get_length_seconds();
                        }
                    }

                    // Найдём авиарейс с максимальной длительностью полёта
                    foreach (Flight w in list)
                    {
                        if (w.Get_length_seconds() == maxlength)
                            w.Out_Flight_Info();
                    }
                    break;

                default:
                    // Что-то не то
                    break;
            }
        }
    }
}