using System;

namespace lr4
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите ссылку:");
            string url = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Введите глубину поиска:");
            bool isParsed = int.TryParse(Console.ReadLine(), out int depth);
            while (!isParsed)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректные данные. Попробуйте ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите глубину поиска:");
                isParsed = int.TryParse(Console.ReadLine(), out depth);
            }

            Console.WriteLine();
            Console.WriteLine("Введите количество просматриваемых страниц:");
            isParsed = int.TryParse(Console.ReadLine(), out int count);
            while (!isParsed)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректные данные. Попробуйте ещё раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите количество просматриваемых страниц:");
                isParsed = int.TryParse(Console.ReadLine(), out count);
            }

            Scan scan = new Scan(depth, count, url);
            Console.WriteLine();

            scan.AddressFound += (pageTitle, link, depth, address) =>
            {
                Console.WriteLine($"Найден адрес по ссылке: {link}");
                Console.WriteLine($"Название: {pageTitle}");
                Console.WriteLine($"Адрес: {address}");
                Console.WriteLine($"Глубина: {depth}");
                Console.WriteLine();
            };

            scan.PhoneNumberFound += (pageTitle, link, depth, phoneNumber) =>
            {
                Console.WriteLine($"Найден номер телефона по ссылке: {link}");
                Console.WriteLine($"Название: {pageTitle}");
                Console.WriteLine($"Номер телефона: {phoneNumber}");
                Console.WriteLine($"Глубина: {depth}");
                Console.WriteLine();
            };

            try
            {
                scan.Process(url);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В процессе работы программы возникла ошибка. Попробуйте проверить адрес.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("Введите название .csv файла:");
            string name = Console.ReadLine();

            if (!name.EndsWith(".csv"))
            {
                scan.CreateFile($"{name}.csv");
            }
            else
            {
                scan.CreateFile(name);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Работа программы завершена.");
            Console.ForegroundColor = ConsoleColor.White;

            scan.client.Dispose();
        }
    }
}