using System;

namespace lr3
{
    internal abstract class Building
    {
        private FlatType _flatType;
        private BuildingType _buildingType;
        private int _flatsCount;
        private double _square;
        private string _address;

        protected static readonly Dictionary<FlatType, int> _roomsCount = new Dictionary<FlatType, int>
        {
            [FlatType.Economy] = 2,
            [FlatType.Business] = 3,
            [FlatType.Elite] = 4
        };

        protected Building(BuildingType buildingType, FlatType type, int flatsCount, string address)
        {
            BuildingType = buildingType;
            FlatType = type;
            FlatsCount = flatsCount;
            Address = address;
        }

        protected Building(BuildingType buildingType, double square, string address)
        {
            BuildingType = buildingType;
            FlatType = FlatType.None;
            Square = square;
            Address = address;
        }

        public FlatType FlatType
        {
            get { return _flatType; }
            set { _flatType = value; }
        }

        public BuildingType BuildingType
        {
            get { return _buildingType; }
            set { _buildingType = value; }
        }

        public int FlatsCount
        {
            get { return _flatsCount; }
            set { _flatsCount = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public double Square
        {
            get { return _square; }
            set { _square = value; }
        }

        public abstract double Average { get; }
    }
}
