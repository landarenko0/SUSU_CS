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

        public int BuildingsCount { get { return _buildings.Count; } }

        public void Add(Building building)
        {
            if (building == null|| string.IsNullOrEmpty(building.Address))
            {
                throw new Exception("Что-то не так...");
            }

            _buildings.Add(building);
            Sort();
        }

        public List<Building> GetBuildings()
        {
            return _buildings;
        }

        private void Sort()
        {
            _buildings.Sort(new Comparer());
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
