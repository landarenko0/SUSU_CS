using System;
using Newtonsoft.Json;

namespace lr3
{
    internal class ManagementCompany
    {
        private readonly List<Building> _buildings = new List<Building>();

        public double TotalCount
        {
            get
            {
                double count = 0;

                foreach (Building building in _buildings)
                {
                    count += building.Average;
                }

                return count;
            }
        }

        public void Add(Building building)
        {
            if (building == null|| string.IsNullOrEmpty(building.Address))
            {
                throw new Exception("Что-то не так...");
            }

            _buildings.Add(building);
            Sort();
        }

        public IEnumerable<Building> GetBuildings()
        {
            return _buildings;
        }
        

        public void GetBuildingsInformation()
        {
            foreach (Building building in _buildings)
            {
                Console.WriteLine($"Тип строения: {building.BuildingType}");
                Console.WriteLine($"Адрес строения: {building.Address}");
                Console.WriteLine($"Количество жильцов/работников строения: {building.Average}");
                Console.WriteLine();
            }
        }

        private void Sort()
        {
            _buildings.Sort(new Comparer());
        }

        public void GetFirstTwoObjects()
        {
            if (_buildings.Count < 2)
            {
                throw new Exception("Общее количество зданий меньше 2.");
            }
            
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Тип строения: {_buildings[i].BuildingType}");
                Console.WriteLine($"Адрес строения: {_buildings[i].Address}");
                Console.WriteLine($"Количество жильцов/работников строения: {_buildings[i].Average}");
                Console.WriteLine();
            }
        }

        public void GetLastThreeAddresses()
        {
            if (_buildings.Count < 3)
            {
                throw new Exception("Общее количество зданий меньше 3.");
            }

            for (int i = _buildings.Count - 3; i < _buildings.Count; i++)
            {
                Console.WriteLine($"Адрес строения: {_buildings[i].Address}");
                Console.WriteLine();
            }
        }

        public void ToJson(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(_buildings, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
        }

        public static ManagementCompany FromJson(string fileName)
        {
            ManagementCompany company = new ManagementCompany();

            var buildings = JsonConvert.DeserializeObject<List<Building>>(File.ReadAllText(fileName), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            if (buildings != null)
            {
                company._buildings.AddRange(buildings);
            }

            return company;
        }
    }
}
