using System;

namespace lr3
{
    internal class ResidentalBuilding : Building
    {
        private const double k = 1.2;

        public ResidentalBuilding(FlatType type, int flatsCount, string address) : base(BuildingType.Residental, type, flatsCount, address)
        {

        }

        public override double Average
        {
            get { return _roomsCount[FlatType] * FlatsCount * k; }
        }
    }
}
