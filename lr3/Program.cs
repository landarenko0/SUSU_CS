using System;

namespace lr3
{
    public class Program
    {
        static int count = 0;
        
        public static void Main()
        {
            ManagementCompany company = new ManagementCompany();

            while (BuildingsCreating(company)) { }

            const string fileName = "MyMС.json";
            Console.WriteLine(Path.GetExtension(fileName));
            company.ToJson(fileName);

            try
            {
                ManagementCompany myNewCompany = ManagementCompany.FromJson(fileName);

                foreach (var building in myNewCompany.GetBuildings())
                {
                    Console.WriteLine($"Тип строения: {building.BuildingType}");
                    Console.WriteLine($"Адрес строения: {building.Address}");
                    Console.WriteLine($"Количество жильцов/работников строения: {building.Average}");
                    Console.WriteLine();
                }

                Console.WriteLine($"\nTotal count = {myNewCompany.TotalCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
    }
}