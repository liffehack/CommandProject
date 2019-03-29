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

        
        public class Flight
        {
            private int num_r;            // номер авиарейса
            private DateTime time_start;  // время вылета
            private DateTime time_finish; // время прибытия
            private string napravlenie;   // направление
            private string marka;         // марка самолёта
            private int distance;         // расстояние
            public Flight() { }

            
            public Flight(int NUM_R, DateTime TIME_START, DateTime TIME_FINISH, string NAPRAVLENIE, string MARKA, int DISTANCE)
            {
                num_r = NUM_R;
                napravlenie = NAPRAVLENIE;
                time_start = TIME_START;
                time_finish = TIME_FINISH;
                marka = MARKA;
                distance = DISTANCE;
            }

            
            public void print_all()
            {
                Console.WriteLine("Номер авиарейса: " + num_r);
                Console.WriteLine("Время вылета: " + time_start);
                Console.WriteLine("Время прилета: " + time_finish);
                Console.WriteLine("Направление: " + napravlenie);
                Console.WriteLine("Марка самолёта: " + marka);
                Console.WriteLine("Расстояние: " + distance);
                Console.WriteLine("_________________________" + distance);
            }

        }




        static void Main(string[] args)
        {
            //Создаем список структуры авиарейса
            List<Flight> list = new List<Flight>();
            string napravlenie, marka;
            int num_r, hour, minits, distance;
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("\t\t Выберите пункт меню: ");
                Console.WriteLine("1.	Ввести в список еще один элемент");
                Console.WriteLine("2.	Вывести весь список. Вывести вместе с полями все элементы.");
                Console.WriteLine("3.	Вывести отфильтрованный список.(по умолчанию фильтр пуст).");
                Console.WriteLine("4.	Ввести значения фильтра.");
                Console.WriteLine("5.	Выйти из программы.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("Vvedite parametry: ");
                    Console.Write("Name is: ");
                    num_r = int.Parse(Console.ReadLine());
                    Console.Write("Hour: ");
                    hour = int.Parse(Console.ReadLine());
                    Console.Write("Minits: ");
                    minits = int.Parse(Console.ReadLine());
                    Console.Write("Napravlenie: ");
                    napravlenie = Console.ReadLine();
                    Console.Write("Marka: ");
                    marka = Console.ReadLine();
                    Console.Write("Distance: ");
                    distance = int.Parse(Console.ReadLine());
                    list.Add(new Flight(num_r, new DateTime(hour, 00, 00), new DateTime(00, minits, 00), napravlenie, marka, distance));
                }
                if (cki.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    foreach (Flight i in list) ;
                        //i.print_info();
                }
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Enter);

            
        }
    }
}