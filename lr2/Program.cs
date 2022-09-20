using System;

namespace lr2
{
    public class Program
    {
        static int count = 0;
        
        static void Main(string[] args)
        {
            Str str1 = stringCreating();
            Str str2 = stringCreating();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("Строки созданы! Переходим в главное меню...");
            Console.WriteLine("Примечание. Если Вы изменить строку, перезапустите программу.");
            Console.WriteLine("При работе с программой цвет символов будет меняться для удобства чтения.");
            Console.WriteLine();
            Start();

            bool isLaunched = true;

            while (isLaunched)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    // Сравнение строк
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine($"Строки равны: {str1 == str2}");
                        Console.WriteLine($"Строки не равны: {str1 != str2}");
                        Console.WriteLine();
                        break;

                    // Конкатенация строк
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine(str1 + str2);
                        Console.WriteLine();
                        break;

                    // Умножение строки на n
                    case "3":
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Выберите строку, которую Вы хотите умножить (1 или 2):");
                        string numOfString = Console.ReadLine();

                        while (numOfString != "1" && numOfString != "2")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            numOfString = Console.ReadLine();
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                        Console.WriteLine("Введите натуральное число, на которое Вы хотите умножить строку:");
                        bool isParsed = Int32.TryParse(Console.ReadLine(), out int n);

                        while (!isParsed || n <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            isParsed = Int32.TryParse(Console.ReadLine(), out n);
                            Console.WriteLine();
                        }

                        switch (numOfString)
                        {
                            case "1":
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine();
                                Console.WriteLine($"Вы выбрали строку {numOfString}: " + str1);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(str1 * n);
                                Console.WriteLine();
                                break;

                            case "2":
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine();
                                Console.WriteLine($"Вы выбрали строку {numOfString}: " + str2);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(str2 * n);
                                Console.WriteLine();
                                break;
                        }

                        break;

                    // Выход из программы
                    case "exit":
                        isLaunched = false;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Такого действия нет. Введите цифру еще раз.");
                        Console.WriteLine();
                        break;
                }

                if (isLaunched)
                {
                    Start();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Работа программы завершена.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Это начальное меню программы. Программа обладает следующими возможностями:");
            Console.WriteLine("1. Сравнение строк;");
            Console.WriteLine("2. Конкатенация (слияние) строк;");
            Console.WriteLine("3. Умножение строки на число n (повторение строки n раз).\n");
            Console.WriteLine("Действия со строками, описанные выше, пронумерованы.");
            Console.WriteLine("Чтобы выбрать какое-либо действие, напишите цифру этого действия в консоль.");
            Console.WriteLine("Чтобы завершить работу программы, напишите 'exit'.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ваш выбор: ");
        }

        static Str stringCreating()
        {
            if (count == 0)
            {
                Console.WriteLine("Привет! Для начала работы нужно создать 2 строки.");
                Console.WriteLine("Создание 1-й строки...");
                count++;
            }
            else
            {
                Console.WriteLine("Создание 2-й строки...");
            }

            Console.WriteLine("Введите строку:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Строка создана!\n");

            return new Str(str1);
        }
    }
}