using System;

namespace lr3
{
    public class Program
    {
        static int count = 0;
        
        public static void Main()
        {
            Console.WriteLine("Вы хотите самостоятельно создавать здания?");
            Console.WriteLine();
            Console.WriteLine("1. Да, я хочу самостоятельно создавать здания;");
            Console.WriteLine("2. Нет, у меня есть уже готовый .json файл, который я хочу десереализовать.");
            Console.WriteLine();

            string choise = Console.ReadLine();

            while (!(choise == "1" || choise == "2"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный ввод данных. Попробуйте снова.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Вы хотите самостоятельно создавать здания?");
                Console.WriteLine();
                Console.WriteLine("1. Да, я хочу самостоятельно создавать здания;");
                Console.WriteLine("2. Нет, у меня есть уже готовый .json файл, который я хочу десереализовать.");
                Console.WriteLine();

                choise = Console.ReadLine();
            }

            switch(choise)
            {
                case "1":
                    Console.Clear();                  
                    Console.WriteLine("Как Вы хотите назвать .json файл? (формат файла указывать необязательно)");
                    Console.WriteLine();
                    string name = Console.ReadLine();
                    if (!name.EndsWith(".json"))
                    {
                        name += ".json";
                    }
                    UserCreating(name);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Введите название файла (не забудьте указать формат файла! Например: file.json) или путь до него:");
                    Console.WriteLine();
                    string fileName = Console.ReadLine();
                    while (!File.Exists(fileName))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Файла с таким именем не существует, проверьте правильность написания.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Введите название файла или путь до него:");
                        Console.WriteLine();
                        fileName = Console.ReadLine();
                    }
                    UserJson(fileName);
                    break;
            }
        }

        static bool BuildingsCreating(ManagementCompany company)
        {
            Console.Clear();
            
            if (count != 0)
            {
                Console.WriteLine($"Зданий создано: {count}");
                Console.WriteLine();
            }

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
            count++;
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
            Console.WriteLine("4. Изменить данные в имеющемся списке зданий.");

            Console.WriteLine();
            Console.WriteLine("Чтобы выбрать нужное действие, введите его номер.");
            Console.WriteLine();
            Console.WriteLine("Чтобы завершить работу программы и сохранить данные, введите 'exit'.");
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

        static void UserCreating(string fileName)
        {
            if (Path.GetExtension(fileName) == ".json")
            {
                ManagementCompany company = new ManagementCompany();

                while (BuildingsCreating(company)) { }

                // Сереализация
                company.ToJson(fileName);

                // Десереализация
                ManagementCompany myNewCompany = ManagementCompany.FromJson(fileName);

                List<Building> buildings = myNewCompany.GetBuildings();

                bool isRunning = true;
                while (isRunning)
                {
                    Start(myNewCompany.BuildingsCount);

                    string choise = Console.ReadLine();
                    Console.WriteLine();

                    switch (choise)
                    {
                        case "1":
                            GetBuildingsInformation(buildings, myNewCompany.TotalCount);
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

                        case "4":
                            ChangeData(myNewCompany, fileName);
                            break;

                        case "exit":
                            Serialize(fileName, myNewCompany);
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
                Console.WriteLine("Неверный формат файла. Формат файла должен быть .json");
            }
        }

        static void UserJson(string fileName)
        {
            try
            {
                if (Path.GetExtension(fileName) == ".json")
                {
                    // Десереализация
                    ManagementCompany myNewCompany = ManagementCompany.FromJson(fileName);

                    List<Building> buildings = myNewCompany.GetBuildings();

                    count = buildings.Count;

                    bool isRunning = true;
                    while (isRunning)
                    {
                        Start(myNewCompany.BuildingsCount);

                        string choise = Console.ReadLine();
                        Console.WriteLine();

                        switch (choise)
                        {
                            case "1":
                                GetBuildingsInformation(buildings, myNewCompany.TotalCount);
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

                            case "4":
                                ChangeData(myNewCompany, fileName);
                                break;

                            case "exit":
                                Serialize(fileName, myNewCompany);
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
                    Console.WriteLine("Неверный формат файла. Формат файла должен быть .json");
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла ошибка на этапе выполнения программы. Проверьте .json файл.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Serialize(string fileName, ManagementCompany company)
        {
            company.ToJson(fileName);
        }

        static void ChangeData(ManagementCompany company, string fileName)
        {
            Console.Clear();
            Console.WriteLine("Что Вы хотите сделать?");
            Console.WriteLine();
            Console.WriteLine("1. Добавить здание;");
            Console.Write("2. Удалить здание.");
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Недоступно, т.к. количество зданий равно 0.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Чтобы выбрать нужное действие, введите его номер.");
            Console.WriteLine();

            string choise = Console.ReadLine();
            while (!(choise == "1" || choise == "2"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный ввод данных. Попробуйте снова.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Что Вы хотите сделать?");
                Console.WriteLine();
                Console.WriteLine("1. Добавить здание;");
                Console.Write("2. Удалить здание.");
                if (count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" Недоступно, т.к. количество зданий равно 0.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Чтобы выбрать нужное действие, введите его номер.");
                Console.WriteLine();

                choise = Console.ReadLine();
            }

            switch (choise)
            {
                case "1":
                    while (BuildingsCreating(company)) { }
                    break;

                case "2":
                    if (count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Недоступно, т.к. количество зданий равно 0.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Чтобы продолжить, нажмите Enter.");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                    }
                    DeleteBuilding(company);
                    break;
            }

            Serialize(fileName, company);
        }

        static void DeleteBuilding(ManagementCompany company)
        {
            Console.Clear();

            var buildings = company.GetBuildings();

            for (int i = 0; i < buildings.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Адрес: {buildings[i].Address}; количество человек: {buildings[i].Average}");
            }

            Console.WriteLine();
            Console.WriteLine("Какое здание Вы хотите удалить?");
            Console.WriteLine();

            bool isParsed = int.TryParse(Console.ReadLine(), out int choise);

            while (!isParsed || choise > buildings.Count || choise <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверно введенные данные. Попробуйте еще раз.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < buildings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Адрес: {buildings[i].Address}; количество человек: {buildings[i].Average}");
                }
                Console.WriteLine();
                Console.WriteLine("Какое здание Вы хотите удалить?");
                Console.WriteLine();

                isParsed = int.TryParse(Console.ReadLine(), out choise);
            }

            buildings.RemoveAt(choise - 1);
            count--;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Здание успешно удалено.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Нажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }
    }
}