using System;
using Newtonsoft.Json;

namespace lr3
{
    internal class NotResidentalBuilding : Building
    {
        private const double k = 0.2;
        public double Square { get; private set; }

        [JsonConstructor]
        public NotResidentalBuilding(double square, string address) : base(BuildingType.NotResidental, address)
        {
            Square = square;
        }

        public override double Average
        {
            get { return Square * k; }
        }
    }
}
