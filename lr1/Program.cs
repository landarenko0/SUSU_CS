using System;

namespace lr1
{
    public class Program
    {
        static int count = 0;
        
        static void Main(string[] args)
        {
            paral paral1 = CreatingParals();
            paral paral2 = CreatingParals();
            Console.WriteLine("Параллелепипеды созданы! Переходим в главное меню...\n");
            Start();

            bool isLaunched = true;

            while (isLaunched)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    // Перемещение параллелепипеда в пространстве
                    case "1":
                        Console.WriteLine("Напишите номер параллелепипеда, который Вы хотите переместить (1 или 2):");
                        string numOfParal;
                        bool isCorrect = true;

                        while (isCorrect)
                        {
                            numOfParal = Console.ReadLine();

                            switch (numOfParal)
                            {
                                case "1":
                                    Console.WriteLine("Перемещения 1-го параллелепипеда в пространстве...");
                                    Console.WriteLine("Введите новую координату x:");
                                    bool isParsed = Double.TryParse(Console.ReadLine(), out double _x0);

                                    while (!isParsed)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _x0);
                                    }

                                    Console.WriteLine("Введите новую координату y:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out double _y0);
                                    while (!isParsed)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _y0);
                                    }

                                    Console.WriteLine("Введите новую координату z:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out double _z0);
                                    while (!isParsed)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _z0);
                                    }

                                    paral1.Move(_x0, _y0, _z0);
                                    Console.WriteLine();
                                    Console.WriteLine("Параллелепипед перемещен! Новые координаты:");
                                    Console.WriteLine(paral1.printCoordinates());
                                    Console.WriteLine();
                                    Thread.Sleep(2000);

                                    isCorrect = false;
                                    break;

                                case "2":
                                    Console.WriteLine("Перемещения 2-го параллелепипеда в пространстве...");
                                    Console.WriteLine("Введите новую координату x:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out _x0);

                                    while (!isParsed)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _x0);
                                    }

                                    Console.WriteLine("Введите новую координату y:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out _y0);
                                    while (!isParsed)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _y0);
                                    }

                                    Console.WriteLine("Введите новую координату z:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out _z0);
                                    while (!isParsed)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _z0);
                                    }

                                    paral2.Move(_x0, _y0, _z0);
                                    Console.WriteLine();
                                    Console.WriteLine("Параллелепипед перемещен! Новые координаты:");
                                    Console.WriteLine(paral2.printCoordinates());
                                    Console.WriteLine();
                                    Thread.Sleep(2000);

                                    isCorrect = false;
                                    break;

                                default:
                                    Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                    Console.WriteLine();
                                    break;
                            }
                        }

                        break;

                    // Изменение размеров параллелепипеда
                    case "2":
                        Console.WriteLine("Напишите номер параллелепипеда, размеры которого Вы хотите изменить (1 или 2):");

                        isCorrect = true;

                        while (isCorrect)
                        {
                            numOfParal = Console.ReadLine();

                            switch (numOfParal)
                            {
                                case "1":
                                    Console.WriteLine("Изменение размеров 1-го параллелепипеда...");
                                    Console.WriteLine("Введите новую ширину:");
                                    bool isParsed = Double.TryParse(Console.ReadLine(), out double _width);

                                    if (!isParsed || _width <= 0)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _width);
                                    }

                                    Console.WriteLine("Введите новую длину:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out double _length);
                                    if (!isParsed || _length <= 0)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _length);
                                    }

                                    Console.WriteLine("Введите новую высоту:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out double _height);
                                    if (!isParsed || _height <= 0)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _height);
                                    }

                                    paral1.Resize(_length, _width, _height);
                                    Console.WriteLine();
                                    Console.WriteLine("Размеры параллелепипеда изменены! Новые размеры:");
                                    Console.WriteLine(paral1);
                                    Thread.Sleep(2000);
                                    Console.WriteLine();

                                    isCorrect = false;
                                    break;

                                case "2":
                                    Console.WriteLine("Изменение размеров 2-го параллелепипеда...");
                                    Console.WriteLine("Введите новую ширину:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out _width);

                                    if (!isParsed || _width <= 0)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _width);
                                    }

                                    Console.WriteLine("Введите новую длину:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out _length);
                                    if (!isParsed || _length <= 0)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _length);
                                    }

                                    Console.WriteLine("Введите новую высоту:");
                                    isParsed = Double.TryParse(Console.ReadLine(), out _height);
                                    if (!isParsed || _height <= 0)
                                    {
                                        Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                        isParsed = Double.TryParse(Console.ReadLine(), out _height);
                                    }

                                    paral1.Resize(_length, _width, _height);
                                    Console.WriteLine();
                                    Console.WriteLine("Размеры параллелепипеда изменены! Новые размеры:");
                                    Console.WriteLine(paral2);
                                    Thread.Sleep(2000);
                                    Console.WriteLine();

                                    isCorrect = false;
                                    break;

                                default:
                                    Console.WriteLine("Неверно введенные данные, попробуйте еще раз.");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;

                    // Построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда
                    case "3":
                        Console.WriteLine("Построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда...");
                        Console.WriteLine(paral1.Union(paral2));
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        break;

                    // Построение параллелепипед, являющегося пересечением двух заданных параллелепипедов
                    case "4":
                        Console.WriteLine("Построение параллелепипеда, являющегося пересечением двух заданных параллелепипедов...");
                        Console.WriteLine(paral1.Intersection(paral2));
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        break;

                    // Выход из программы
                    case "exit":
                        isLaunched = false;
                        break;

                    default:
                        Console.WriteLine("Такого действия нет. Введите цифру еще раз.");
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        break;
                }

                Start();
            }

            Console.WriteLine("Работа программы завершена.");
        }

        static void Start()
        {
            Console.WriteLine("Это начальное меню программы. Программа обладает следующими возможностями:");
            Console.WriteLine("1. Перемещение параллелепипеда в пространстве;");
            Console.WriteLine("2. Изменение размеров параллелепипеда;");
            Console.WriteLine("3. Построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда;");
            Console.WriteLine("4. Построение параллелепипеда, являющегося пересечением двух заданных параллелепипедов.\n");
            Console.WriteLine("Действия с параллелепипедами, описанные выше, пронумерованы.");
            Console.WriteLine("Чтобы выбрать какое-либо действие, напишите цифру этого действия в консоль.");
            Console.WriteLine("Чтобы завершить работу программы, напишите 'exit'.");
        }

        static paral CreatingParals()
        {
            if (count == 0)
            {
                Console.WriteLine("Привет! Для начала работы нужно создать 2 параллелепипеда.");
                Console.WriteLine("Примечание. Начальная точка - это левая нижняя точка нижней поверхности параллелепипеда.");
                Console.WriteLine("Создание 1-го параллелепипеда...");
                count++;
            }
            else
            {
                Console.WriteLine("Создание 2-го параллелепипеда...");
            }

            Console.WriteLine("Введите x координату начальной точки:");
            bool isParsed = Double.TryParse(Console.ReadLine(), out double x0);

            while (!isParsed)
            {
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                isParsed = Double.TryParse(Console.ReadLine(), out x0);
            }

            Console.WriteLine("Введите y координату начальной точки:");
            isParsed = Double.TryParse(Console.ReadLine(), out double y0);

            while (!isParsed)
            {
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                isParsed = Double.TryParse(Console.ReadLine(), out y0);
            }

            Console.WriteLine("Введите z координату начальной точки:");
            isParsed = Double.TryParse(Console.ReadLine(), out double z0);

            while (!isParsed)
            {
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                isParsed = Double.TryParse(Console.ReadLine(), out z0);
            }

            Console.WriteLine("Введите ширину параллелепипеда:");
            isParsed = Double.TryParse(Console.ReadLine(), out double width0);

            while (!isParsed || width0 <= 0)
            {
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                isParsed = Double.TryParse(Console.ReadLine(), out width0);
            }

            Console.WriteLine("Введите длину параллелепипеда:");
            isParsed = Double.TryParse(Console.ReadLine(), out double length0);

            while (!isParsed || length0 <= 0)
            {
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                isParsed = Double.TryParse(Console.ReadLine(), out length0);
            }

            Console.WriteLine("Введите высоту параллелепипеда:");
            isParsed = Double.TryParse(Console.ReadLine(), out double height0);

            while (!isParsed || height0 <= 0)
            {
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                isParsed = Double.TryParse(Console.ReadLine(), out height0);
            }
            Console.WriteLine();

            return new paral(x0, y0, z0, width0, length0, height0);
        }
    }
}