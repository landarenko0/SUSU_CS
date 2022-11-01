using System;
using Newtonsoft.Json;

namespace lr3
{
    internal abstract class Building
    {
        [JsonConstructor]
        protected Building(BuildingType buildingType, string address)
        {
            BuildingType = buildingType;
            Address = address;
        }

        public BuildingType BuildingType { get; private set; }

        public string Address { get; private set; }

        public abstract double Average { get; }
    }
}
