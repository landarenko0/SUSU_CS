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
            
            Console.Clear();
            Start();

            bool isLaunched = true;

            while (isLaunched)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    // Перемещение параллелепипеда в пространстве
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Напишите номер параллелепипеда, который Вы хотите переместить (1 или 2):");
                        string numOfParal = Console.ReadLine();

                        while (!(numOfParal == "1" || numOfParal == "2"))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.WriteLine("Напишите номер параллелепипеда, который Вы хотите переместить (1 или 2):");
                            numOfParal = Console.ReadLine();
                        }

                        switch (numOfParal)
                        {
                            case "1":
                                Console.Clear();
                                Move(paral1);
                                break;

                            case "2":
                                Console.Clear();
                                Move(paral2);
                                break;
                        }

                        break;

                    // Изменение размеров параллелепипеда
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Напишите номер параллелепипеда, размеры которого Вы хотите изменить (1 или 2):");
                        numOfParal = Console.ReadLine();

                        while (!(numOfParal == "1" || numOfParal == "2"))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.WriteLine("Напишите номер параллелепипеда, размеры которого Вы хотите изменить (1 или 2):");
                            numOfParal = Console.ReadLine();
                        }

                        switch (numOfParal)
                        {
                            case "1":
                                Console.Clear();
                                ChangeSize(paral1);
                                break;

                            case "2":
                                Console.Clear();
                                ChangeSize(paral2);
                                break;
                        }

                        break;

                    // Построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда
                    case "3":
                        Console.Clear();
                        Console.WriteLine(paral1.Union(paral2));
                        break;

                    // Построение параллелепипед, являющегося пересечением двух заданных параллелепипедов
                    case "4":
                        Console.Clear();
                        Console.WriteLine(paral1.Intersection(paral2));
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Первый параллелепипед:");
                        Console.WriteLine();
                        Console.WriteLine(paral1.printCoordinates());
                        Console.WriteLine(paral1);
                        Console.WriteLine();
                        Console.WriteLine("Второй параллелепипед:");
                        Console.WriteLine();
                        Console.WriteLine(paral2.printCoordinates());
                        Console.WriteLine(paral2);
                        break;

                    // Выход из программы
                    case "exit":
                        Console.WriteLine("Работа программы завершена.");
                        isLaunched = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Такого действия нет. Введите цифру еще раз.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                if (isLaunched)
                {
                    Console.WriteLine();
                    Console.WriteLine("Чтобы продолжить, нажмите Enter.");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                }
            }
        }

        static void Start()
        {
            Console.WriteLine("Это начальное меню программы. Программа обладает следующими возможностями:");
            Console.WriteLine("1. Перемещение параллелепипеда в пространстве;");
            Console.WriteLine("2. Изменение размеров параллелепипеда;");
            Console.WriteLine("3. Построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда;");
            Console.WriteLine("4. Построение параллелепипеда, являющегося пересечением двух заданных параллелепипедов.;");
            Console.WriteLine("5. Вывод на экран значения координат и длин сторон параллелепипедов.\n");
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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите x координату начальной точки:");
                isParsed = Double.TryParse(Console.ReadLine(), out x0);
            }

            Console.Clear();
            Console.WriteLine("Введите y координату начальной точки:");
            isParsed = Double.TryParse(Console.ReadLine(), out double y0);

            while (!isParsed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите y координату начальной точки:");
                isParsed = Double.TryParse(Console.ReadLine(), out y0);
            }

            Console.Clear();
            Console.WriteLine("Введите z координату начальной точки:");
            isParsed = Double.TryParse(Console.ReadLine(), out double z0);

            while (!isParsed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите z координату начальной точки:");
                isParsed = Double.TryParse(Console.ReadLine(), out z0);
            }

            Console.Clear();
            Console.WriteLine("Введите длину параллелепипеда:");
            isParsed = Double.TryParse(Console.ReadLine(), out double length0);

            while (!isParsed || length0 <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите длину параллелепипеда:");
                isParsed = Double.TryParse(Console.ReadLine(), out length0);
            }

            Console.Clear();
            Console.WriteLine("Введите ширину параллелепипеда:");
            isParsed = Double.TryParse(Console.ReadLine(), out double width0);

            while (!isParsed || width0 <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите ширину параллелепипеда:");
                isParsed = Double.TryParse(Console.ReadLine(), out width0);
            }

            Console.Clear();
            Console.WriteLine("Введите высоту параллелепипеда:");
            isParsed = Double.TryParse(Console.ReadLine(), out double height0);

            while (!isParsed || height0 <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите высоту параллелепипеда:");
                isParsed = Double.TryParse(Console.ReadLine(), out height0);
            }
            Console.Clear();

            return new paral(x0, y0, z0, length0, width0, height0);
        }

        static void Move(paral paral) 
        {
            Console.WriteLine("Введите новую координату x:");
            bool isParsed = Double.TryParse(Console.ReadLine(), out double _x0);

            while (!isParsed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите новую координату x:");
                isParsed = Double.TryParse(Console.ReadLine(), out _x0);
            }

            Console.Clear();
            Console.WriteLine("Введите новую координату y:");
            isParsed = Double.TryParse(Console.ReadLine(), out double _y0);
            while (!isParsed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите новую координату y:");
                isParsed = Double.TryParse(Console.ReadLine(), out _y0);
            }

            Console.Clear();
            Console.WriteLine("Введите новую координату z:");
            isParsed = Double.TryParse(Console.ReadLine(), out double _z0);
            while (!isParsed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите новую координату z:");
                isParsed = Double.TryParse(Console.ReadLine(), out _z0);
            }

            paral.Move(_x0, _y0, _z0);

            Console.Clear();
            Console.WriteLine("Параллелепипед перемещен! Новые координаты:");
            Console.WriteLine(paral.printCoordinates());
        }

        static void ChangeSize(paral paral) 
        {
            Console.WriteLine("Введите новую длину:");
            bool isParsed = Double.TryParse(Console.ReadLine(), out double _length);

            while (!isParsed || _length <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите новую длину:");
                isParsed = Double.TryParse(Console.ReadLine(), out _length);
            }

            Console.Clear();
            Console.WriteLine("Введите новую ширину:");
            isParsed = Double.TryParse(Console.ReadLine(), out double _width);
            while (!isParsed || _width <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите новую ширину:");
                isParsed = Double.TryParse(Console.ReadLine(), out _width);
            }

            Console.Clear();
            Console.WriteLine("Введите новую высоту:");
            isParsed = Double.TryParse(Console.ReadLine(), out double _height);
            while (!isParsed || _height <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Введите новую высоту:");
                isParsed = Double.TryParse(Console.ReadLine(), out _height);
            }

            paral.Resize(_length, _width, _height);
            Console.Clear();
            Console.WriteLine("Размеры параллелепипеда изменены! Новые размеры:");
            Console.WriteLine(paral);
        }

    }
}