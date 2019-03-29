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
            // Создаем список структуры авиарейса
            List<Flight> list = new List<Flight>();
            
            // Заполняем список
            list.Add(new Flight(1, new DateTime(2015, 7, 20, 19, 00, 00), new DateTime(2015, 7, 21, 18, 30, 00), "Moscow->Cheb", "CHINA", 1000));
            list.Add(new Flight(2, new DateTime(2015, 7, 22, 08, 00, 00), new DateTime(2015, 7, 23, 09, 00, 00), "Cheb->Moscow", "CHINA", 1000));
            list.Add(new Flight(3, new DateTime(2015, 7, 24, 13, 00, 00), new DateTime(2015, 7, 25, 14, 00, 00), "Moscow->Kazan", "CHINA", 1200));
            list.Add(new Flight(4, new DateTime(2015, 7, 26, 18, 00, 00), new DateTime(2015, 7, 27, 23, 00, 00), "Kazan->Moscow", "CHINA", 1200));
            list.Add(new Flight(5, new DateTime(2015, 7, 28, 17, 00, 00), new DateTime(2015, 7, 29, 21, 00, 00), "Kazan->Cheb", "CHINA", 200));
            list.Add(new Flight(6, new DateTime(2015, 7, 30, 14, 00, 00), new DateTime(2015, 7, 31, 01, 00, 00), "Cheb->Kazan", "CHINA", 200));

            // Объявление переменной для работы с меню
            LengthFilter filter = new LengthFilter();

            // Бесконечный цикл
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
                switch (Console.ReadLine()){
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

                    default: Console.WriteLine("Введите заного: ");
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
            public Flight() { }

            //Инициализация
            public Flight(int NUM_R,  DateTime TIME_START, DateTime TIME_FINISH, string NAPRAVLENIE, string MARKA, int DISTANCE)
                {
                num_r=NUM_R;
                napravlenie = NAPRAVLENIE;
                time_start = TIME_START;
                time_finish = TIME_FINISH;
                marka = MARKA;
                distance = DISTANCE;
                }

            //Получить начало вылета
            public DateTime Get_time_start()
            {
                return this.time_start;
            }

            //Получить время прибытия
            public DateTime Get_time_finish()
            {
                return this.time_finish;
            }

            //Вывод информации об одном авиарейсе
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

            //Вывод всего списка
            public static void Out_All_Flight(ref List<Flight> list)
            {
                Console.Clear();
                foreach (var l in list)
                {
                    l.Out_Flight_Info();
                }
            }

            //Добавление нового рейса
            public static void AddFlight(ref List<Flight> list)
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
                list.Add(fl);
            }

            //Получить длительность полёта в секундах
            public int Get_length_secunds()
            {
                //длительность
                int lentgh = 0;

                //Разница времени finish от start
                int day = time_finish.Day - time_start.Day;
                int hour = time_finish.Hour - time_start.Hour;
                int minute = time_finish.Minute - time_start.Minute;
                int second = time_finish.Second - time_start.Second;

                //Разница в секундах = длительность в секундах
                lentgh = day * 24 * 60 * 60 + hour * 60 * 60 + minute * 60 + second;

                return lentgh;
            }

        }
        #endregion


        #region Структура фильтра по длительности полёта

        class LengthFilter
        {
            private int days;   //Длительность дней полёта
            private int hours;  //Длительность часов полёта
            private int minutes;//Длительность минут полёта
            private int seconds;//Длительность секунд полёта

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
                {
                this.days = days;
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
                }

            // Изменить значение фильтра
            public void ChangeFilterValue(int days, int hours, int minutes, int seconds)
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
            {
                Console.Clear();
                List<Flight> list = new List<Flight>();
                int length = days * 60 * 60 * 24 + hours * 60 * 60 + minutes * 60 + seconds;
                int maxlength=0;
                foreach (Flight w in flights)
                {
                    if (w.Get_length_secunds()>maxlength)
                    {
                        maxlength = w.Get_length_secunds();
                    }
                }

                    foreach (Flight w in flights)
                {
                    // Если значения фильтра не установлено, по умолчанию
                    if (length==0)
                    {
                        if (w.Get_length_secunds() == maxlength)
                            w.Out_Flight_Info();
                        list.Add(w);

                    }
                    // иначе выводим список удовлетворяющих услових
                    else
                    {
                        if(w.Get_length_secunds()>length)
                        {
                            w.Out_Flight_Info();
                            list.Add(w);
                        }
                    }
                }
                return list;
            }

        }
        #endregion    
    }
}