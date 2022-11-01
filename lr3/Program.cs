using System;

namespace lr3
{
    public class Program
    {
        static int count = 0;
        
        public static void Main()
        {
            const string fileName = "MyMС.json";

            if (Path.GetExtension(fileName) == ".json")
            {
                ManagementCompany company = new ManagementCompany();

                while (BuildingsCreating(company)) { }

                // Сереализация
                company.ToJson(fileName);

                // Десереализация
                ManagementCompany myNewCompany = ManagementCompany.FromJson(fileName);

                List<Building> buildings = company.GetBuildings();

                bool isRunning = true;
                while (isRunning)
                {
                    Start(company.BuildingsCount);

                    string choise = Console.ReadLine();
                    Console.WriteLine();

                    switch (choise)
                    {
                        case "1":
                            GetBuildingsInformation(buildings, company.TotalCount);
                            Console.WriteLine();
                            Console.WriteLine("Чтобы продолжить, нажмите клавишу Enter.");
                            Console.ReadLine();
                            break;

                        case "2":
                            if (buildings.Count < 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Функция недоступна. Количество зданий меньше 2-х.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("Чтобы продолжить, нажмите клавишу Enter.");
                                Console.ReadLine();
                                break;
                            }
                            GetFirstTwoObjects(buildings);
                            Console.WriteLine();
                            Console.WriteLine("Чтобы продолжить, нажмите клавишу Enter.");
                            Console.ReadLine();
                            break;

                        case "3":
                            if (buildings.Count < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Функция недоступна. Количество зданий меньше 3-х.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("Чтобы продолжить, нажмите клавишу Enter.");
                                Console.ReadLine();
                                break;
                            }
                            GetLastThreeAddresses(buildings);
                            Console.WriteLine();
                            Console.WriteLine("Чтобы продолжить, нажмите клавишу Enter.");
                            Console.ReadLine();
                            break;

                        case "exit":
                            isRunning = false;
                            Console.WriteLine("Работа программы завершена.");
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверный ввод данных. Попробуйте еще раз.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.WriteLine("Чтобы продолжить, нажмите клавишу Enter.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат файла.");
            }
        }

        static bool BuildingsCreating(ManagementCompany company)
        {
            Console.Clear();
            
            if (count == 0)
            {
                Console.WriteLine("Привет! Для начала работы с программой нужно создать здания.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Зданий создано: {count}");
            }

            count++;

            Console.WriteLine("Выберите тип здания. 1 - жилое, 2 - нежилое. Введите 0, чтобы остановить создание зданий.");
            Console.WriteLine();

            bool isParsed = Int32.TryParse(Console.ReadLine(), out int choice);
            Console.Clear();

            while (!isParsed || (choice != 1 && choice != 2 && choice != 0))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный ввод данных. Попробуйте еще раз.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Выберите тип здания. 1 - жилое, 2 - нежилое. Введите 0, чтобы остановить создание зданий.");
                Console.WriteLine();
                isParsed = Int32.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 0)
            {
                return false;
            }

            Console.Clear();
            Console.WriteLine("Введите адрес здания.");
            Console.WriteLine();

            string address = Console.ReadLine();
            while (string.IsNullOrEmpty(address))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный ввод данных. Попробуйте еще раз.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Введите адрес здания.");
                Console.WriteLine();
                address = Console.ReadLine();
            }

            Console.Clear();

            if (choice == 1)
            {
                // Жилое здание

                Console.WriteLine("Выберите тип квартир в здании. 1 - эконом (2 комнаты), 2 - бизнес-класс (3 комнаты), 3 - элитная (4 комнаты)");
                Console.WriteLine();

                isParsed = Int32.TryParse(Console.ReadLine(), out int type);
                while (!isParsed || (type != 1 && type != 2 && type != 3))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод данных. Попробуйте еще раз.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Выберите тип квартир в здании. 1 - эконом (2 комнаты), 2 - бизнес-класс (3 комнаты), 3 - элитная (4 комнаты)");
                    Console.WriteLine();
                    isParsed = Int32.TryParse(Console.ReadLine(), out type);
                }

                Console.Clear();

                FlatType flatType;
                switch (type)
                {
                    case 1:
                        flatType = FlatType.Economy;
                        break;

                    case 2:
                        flatType = FlatType.Business;
                        break;

                    case 3:
                        flatType = FlatType.Elite;
                        break;

                    default:
                        flatType = FlatType.None;
                        break;
                }

                Console.WriteLine("Введите количество квартир в здании.");
                Console.WriteLine();

                isParsed = Int32.TryParse(Console.ReadLine(), out int count);
                while (!isParsed || count <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод данных. Попробуйте еще раз.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Введите количество квартир в здании.");
                    Console.WriteLine();
                    isParsed = Int32.TryParse(Console.ReadLine(), out count);
                }

                Building building = new ResidentalBuilding(flatType, count, address);
                company.Add(building);
            }
            else if (choice == 2)
            {
                // Нежилое здание

                Console.WriteLine("Введите площадь здания (возможен ввод нецелого цисла).");
                Console.WriteLine();

                isParsed = Double.TryParse(Console.ReadLine(), out double square);

                while (!isParsed || square <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод данных. Попробуйте еще раз.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Введите площадь здания (возможен ввод нецелого числа).");
                    Console.WriteLine();
                    isParsed = Double.TryParse(Console.ReadLine(), out square);
                }

                Building building = new NotResidentalBuilding(square, address);
                company.Add(building);
            }

            return true;
        }

        static void Start(int count)
        {
            Console.Clear();
            Console.WriteLine("Это начальное меню программы. Она обладает следующими возможностями:");
            Console.WriteLine();
            Console.WriteLine("1. Вывод информации (тип строения, адрес, среднее количество человек) обо всех зданиях;");
            Console.Write("2. Вывод информации о первых 2-х зданиях; ");
            if (count < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Недоступно, так как количество зданий меньше 2.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine();
            }
            Console.Write("3. Вывод адресов 3-х последних зданий; ");
            if (count < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Недоступно, так как количество зданий меньше 3.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Чтобы выбрать нужное действие, введите его номер.");
            Console.WriteLine();
            Console.WriteLine("Чтобы завершить работу программы, введите 'exit'.");
            Console.WriteLine();
            Console.Write("Ваш выбор: ");
        }

        static void GetBuildingsInformation(List<Building> buildings, double totalCount)
        {
            foreach (var building in buildings)
            {
                Console.WriteLine($"Тип строения: {building.BuildingType}");
                Console.WriteLine($"Адрес строения: {building.Address}");
                Console.WriteLine($"Количество жильцов/работников строения: {building.Average}");
                Console.WriteLine();
            }

            Console.WriteLine($"\nОбщее количество человек = {totalCount}");
        }

        static void GetFirstTwoObjects(List<Building> buildings)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Тип строения: {buildings[i].BuildingType}");
                Console.WriteLine($"Адрес строения: {buildings[i].Address}");
                Console.WriteLine($"Количество жильцов/работников строения: {buildings[i].Average}");
                Console.WriteLine();
            }
        }

        static void GetLastThreeAddresses(List<Building> buildings)
        {
            for (int i = buildings.Count - 3; i < buildings.Count; i++)
            {
                Console.WriteLine($"Адрес строения: {buildings[i].Address}");
                Console.WriteLine();
            }
        }
    }
}