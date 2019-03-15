using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//jfgobuh
//hello world
namespace Visual_lab3
{
    class Program
    {
        struct product
        {
            private string name;
            private DateTime created;
            private int shelf_life;
            private int price;
            private int serial_number;
            public product(string NAME,DateTime CREATED,int SHELF_LIFE,int PRICE,int NUMBER)
            {
                name = NAME;
                created = CREATED;
                shelf_life = SHELF_LIFE;
                price = PRICE;
                serial_number = NUMBER;
            }
            public void print_all()
            {
                Console.WriteLine("Name is: " + name);
                Console.WriteLine("Date of creation: "+created);
                Console.WriteLine("Shelf life: " + shelf_life);
                Console.WriteLine("Price: " + price);
                Console.WriteLine("Serial number: " + serial_number);
            }
            public void print_info()
            {
                int year=created.Year, month=created.Month, day=created.Day, hour=created.Hour+shelf_life;
                while(hour>=24)
                {
                    hour = hour - 24;
                    day = day + 1;
                    if(day>30)
                    {
                        day = day - 30;
                        month = month + 1;
                    }
                }
                Console.WriteLine("Name is: " + name);
                Console.WriteLine("Date of shelf: " + new DateTime(year,month,day,hour,00,00));
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            List<product> Product=new List<product>();
            string name;
            int year, month, day, hour, hours_of_shelf, price, serial_number;
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("Choose what to do:");
                Console.WriteLine("Enter to exit");
                Console.WriteLine("1-add a new element in a list");
                Console.WriteLine("2-print list");
                cki = Console.ReadKey();
                if(cki.Key==ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("Input the parameters: ");
                    Console.Write("Name is: ");
                    name =Console.ReadLine();
                    Console.Write("Year of creating: ");
                    year = int.Parse(Console.ReadLine());
                    Console.Write("Month of creating: ");
                    month = int.Parse(Console.ReadLine());
                    Console.Write("Day of creating: ");
                    day = int.Parse(Console.ReadLine());
                    Console.Write("Hour: ");
                    hour = int.Parse(Console.ReadLine());
                    Console.Write("Hours of shelf: ");
                    hours_of_shelf = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    price = int.Parse(Console.ReadLine());
                    Console.Write("Serial number: ");
                    serial_number = int.Parse(Console.ReadLine());
                    Product.Add(new product(name, new DateTime(year, month, day, hour, 00, 00), hours_of_shelf, price, serial_number));
                }
                if(cki.Key==ConsoleKey.D2)
                {
                    Console.Clear();
                    foreach (product i in Product)
                        i.print_info();
                }
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Enter);
        }
    }
}
