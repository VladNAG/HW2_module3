using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_module3
{
    public static class Starter
    {
        public static void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var phoneBook = new MyPonebook<Contact>();
            phoneBook.Add(new Contact("Ivan", "04548877"), new CultureInfo("en-US"));
            phoneBook.Add(new Contact("Sergey", "04548877"), new CultureInfo("en-US"));
            phoneBook.Add(new Contact("Вася", "04548877"), new CultureInfo("uk"));
            phoneBook.Add(new Contact("Artem", "04548877"), new CultureInfo("en-US"));
            phoneBook.Add(new Contact("223", "04548874"), new CultureInfo("en-US"));
            phoneBook.Add(new Contact("@@", "04548877"), new CultureInfo("en-US"));
            phoneBook.Add(new Contact("Нiна", "045488722"), new CultureInfo("uk"));
            phoneBook.Add(new Contact("Артем", "04548877"), new CultureInfo("uk"));
            phoneBook.Add(new Contact("Iгнат", "04548877"), new CultureInfo("uk"));

            var sortedContact = phoneBook.OrderBy(c => c.Neme).ToList();
            Console.WriteLine("My PhoneBook!!!");
            Console.WriteLine();
            foreach (var i in sortedContact)
            {
                Console.WriteLine(i.Neme + ":" + i.Pone);
            }
        }
    }
}