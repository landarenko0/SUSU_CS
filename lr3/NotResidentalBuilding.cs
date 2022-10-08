using System;

namespace lr3
{
    internal class NotResidentalBuilding : Building
    {
        private const double k = 0.2;

        public NotResidentalBuilding(FlatType type, double square, string address) : base(BuildingType.NotResidental, type, square, address)
        {

        }

        public override double Average
        {
            get { return _square * k; }
        }
    }
}
