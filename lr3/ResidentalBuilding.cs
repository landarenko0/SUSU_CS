using System;
using Newtonsoft.Json;

namespace lr3
{
    internal class ResidentalBuilding : Building
    {
        private const double k = 1.3;
        [JsonProperty]
        public FlatType FlatType { get; private set; }
        public int FlatsCount { get; private set; }

        private static readonly Dictionary<FlatType, int> _roomsCount = new Dictionary<FlatType, int>
        {
            [FlatType.Economy] = 2,
            [FlatType.Business] = 3,
            [FlatType.Elite] = 4
        };

        [JsonConstructor]
        public ResidentalBuilding(FlatType type, int flatsCount, string address) : base(BuildingType.Residental, address)
        {
            FlatType = type;
            FlatsCount = flatsCount;
        }

        public override double Average
        {
            get { return _roomsCount[FlatType] * FlatsCount * k; }
        }
    }
}
