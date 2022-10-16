using System;

namespace lr3
{
    internal class NotResidentalBuilding : Building
    {
        private const double k = 0.2;

        public NotResidentalBuilding(double square, string address) : base(BuildingType.NotResidental, square, address)
        {

        }

        public override double Average
        {
            get { return Square * k; }
        }
    }
}
