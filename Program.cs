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
			List<Flight> list = new List<Flight>();// Список для авиарейса
			LengthFilter filter = new LengthFilter();// Список фильтра, сюда будем заносить рейсы, удовлетворяющие нашему фильтру
			
            // Бесконечный цикл для главного меню
            while (true)
            {
                // Вывести главное меню
                Console.WriteLine("\t\t Выберите пункт меню: ");
                Console.WriteLine("1.	Ввести в список еще один элемент");
                Console.WriteLine("2.	Вывести весь список. Вывести вместе с полями все элементы.");
                Console.WriteLine("3.	Вывести отфильтрованный список.(по умолчанию фильтр пуст).");
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
                        filter.FilterFlight(list);
                        break;

                    case "4":
                        // Ввод значения фильтра
                        Console.WriteLine("\t\tВвод значения фильтра ");
                        filter.Read_length_filter();
                        break;

                    case "5":
                        // Выход
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Введите заного: ");
                        break;
                }
            }
        }

        #region Объявление структуры Flight
        // Хранит информациаю об авиарейсе и методы для работы с ним
        public class Flight
        {
            private int num_r;            // номер авиарейса
            private DateTime time_start;  // время вылета
            private DateTime time_finish; // время прибытия
            private string napravlenie;   // направление
            private string marka;         // марка самолёта
            private int distance;         // расстояние
            public Flight() {}

            // Инициализация рейса
            public Flight(int NUM_R,  DateTime TIME_START, DateTime TIME_FINISH, string NAPRAVLENIE, string MARKA, int DISTANCE)
                // Параметры=(номер рейса, время вылета, время прибытия, направление, марка самолёта, расстояние)
                {
                num_r=NUM_R;
                napravlenie = NAPRAVLENIE;
                time_start = TIME_START;
                time_finish = TIME_FINISH;
                marka = MARKA;
                distance = DISTANCE;
                }

            // Получить начало вылета
            public DateTime Get_time_start()
            {
                return this.time_start;// Возвращаем дату и время вылета
            }

            // Получить время прибытия
            public DateTime Get_time_finish()
            {
                return this.time_finish;// Возвращаем дату и время прилёта
            }

            // Вывод информации об одном авиарейсе
            public void Out_Flight_Info()
            {
                Console.WriteLine("Номер авиарейса: " + num_r );
                Console.WriteLine("Время вылета: " + time_start);
                Console.WriteLine("Время прилета: " + time_finish);
                Console.WriteLine("Направление: " + napravlenie);
                Console.WriteLine("Марка самолёта: " + marka);
                Console.WriteLine("Расстояние: " + distance);
                Console.WriteLine("_________________________");
            }

            // Вывод всего списка
            public static void Out_All_Flight(ref List<Flight> list)
            {
                Console.Clear();
				// Проходимся по каждому эелементу
                foreach (var l in list)
                {
					// Выводим информацию о элементе
                    l.Out_Flight_Info();
                }
            }

            // Добавление нового рейса
            public static void AddFlight(ref List<Flight> list)			
			// <param name="list">список авиарейса</param>
            {
                //Элемент для добавления
                Flight fl = new Flight();
                Console.Clear();
                Console.Write("Введите номер авиарейса: ");
                fl.num_r =Int32.Parse(Console.ReadLine());
                Console.Write("Введите время вылета в формате [ДД.ММ.ГГГГ HH:MM:SS], строго по этому формату : ");
                fl.time_start = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите время прилета в формате [ДД.ММ.ГГГГДД.ММ.ГГГГ HH:MM:SS] строго по этому формату : ");
                fl.time_finish = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите направление ");
                fl.napravlenie = Console.ReadLine();
                Console.Write("Введите марку самолёта: ");
                fl.marka=Console.ReadLine();
                Console.Write("Введите расстояние: ");
                fl.distance=Int32.Parse(Console.ReadLine());
                // После того как всё ввели, добавляем рейс к нашему списку
                list.Add(fl);
            }

            // Получить длительность полёта в секундах
            public int Get_length_seconds()
            {
                // длительность
                int lentgh = 0;
                // Разница времени прилёта от вылета
                int day = time_finish.Day - time_start.Day;
                int hour = time_finish.Hour - time_start.Hour;
                int minute = time_finish.Minute - time_start.Minute;
                int second = time_finish.Second - time_start.Second;
                // Разница в секундах = длительность в секундах
                lentgh = day * 24 * 60 * 60 + hour * 60 * 60 + minute * 60 + second;
                return lentgh;  // возвращаем длительность полёта в секундах  
            }
        }
        #endregion

        #region Структура фильтра по длительности полёта

        class LengthFilter
        {
            private int days;   // Длительность дней полёта
            private int hours;  // Длительность часов полёта
            private int minutes;// Длительность минут полёта
            private int seconds;// Длительность секунд полёта

            // Инициализация по умолчанию
            public LengthFilter()
            {
                this.days = 0;
                this.hours = 0;
                this.minutes = 0;
                this.seconds = 0;
            }

            // Инициализация фильтра
            public LengthFilter(int days, int hours, int minutes, int seconds)
			// (дни, часы, минуты, секунды)
            {
                this.days = days;
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
             }

            // Изменить значение фильтра
            public void ChangeFilterValue(int days, int hours, int minutes, int seconds)
			// Параметры=(дни, часы, минуты, секунды)
            {
                this.days = days;
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
            }

            // Ввести значение фильтра
            public void Read_length_filter()
            {
                Console.Clear();
                Console.WriteLine("Введите длительность дней полёта <10");
                days = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите длительность часов полёта <60");
                hours = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите длительность минут полёта <60");
                minutes = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите длительность секунд полёта <60 ");
                seconds = Int32.Parse(Console.ReadLine());
            }

            // Фильтрация данных
            public List<Flight> FilterFlight (List<Flight> flights)
			// <param name="flights">список отфильтрованных данных</param>
            {
                Console.Clear();
                List<Flight> list = new List<Flight>();// список для отфильтрованных рейсов
                int length = days * 60 * 60 * 24 + hours * 60 * 60 + minutes * 60 + seconds; // считаем секунды
                int maxlength=0;// максимальная длительность полёта из всего списка рейсов.

                // Предварительный осмотр списка авиарейса, находим максимульную длительность полёта
                foreach (Flight w in flights)
                {
					// если длительносить рейса больше предыдущего то обновляем макс. длительность
                    if (w.Get_length_seconds()>maxlength)
                    {
                        maxlength = w.Get_length_seconds();
                    }
                }

                    foreach (Flight w in flights)
                {
                    // Если значения фильтра не установлено, по умолчанию, то выводим рейс с максимальной длительностью
                    if (length==0)
                    {
						// и если длительность рейса соответствует найденному ранее макс. длительности то выводим этот рейс
                        if (w.Get_length_seconds() == maxlength)
						{
                            w.Out_Flight_Info();
							list.Add(w);
						}
                    }
                    // иначе выводим список, где длительность полёта рейса больше заданной длительности фильтра
                    else
                    {
                        if(w.Get_length_seconds()>length)
                        {
                            w.Out_Flight_Info();
                            list.Add(w);
                        }
                    }
                }
                return list;// Возвращаем отфильтрованнный список
            }

        }
        #endregion
    }
}